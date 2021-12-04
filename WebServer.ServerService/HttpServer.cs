using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using WebServer.ServerService.Http;
using WebServer.ServerService.Routing;

namespace WebServer.ServerService
{
    public class HttpServer
    {
        private readonly IPAddress _ipAddress;
        private readonly int _port;
        private readonly TcpListener _tcpListener;
        private readonly IRoutingTable _routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            _ipAddress = IPAddress.Parse(ipAddress);
            _port = port;

            _tcpListener = new TcpListener(_ipAddress, _port);
            _routingTable = new RoutingTable();
            routingTableConfiguration(_routingTable);
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(5000, routingTable)
        {
        }

        public async Task Start()
        {
            this._tcpListener.Start();

            while (true)
            {
                var connection = await _tcpListener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();
                var requestBody = await ReadRequest(networkStream);
                var request = HttpRequest.Parse(requestBody);
                var response = _routingTable.MatchRequest(request);
                await WriteResponse(networkStream, response);
                connection.Close();
            }
        }

        public void Stop()
        {
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            int bufferLenght = 1024;
            var buffer = new byte[bufferLenght];
            var requestBuilder = new StringBuilder();
            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLenght);

                // here we use bytesRead because if request is 500 bytes we will read only that much of it
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            Console.WriteLine(requestBuilder.ToString());
            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }
    }
}