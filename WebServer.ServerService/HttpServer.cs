using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.ServerService.Http;

namespace WebServer.ServerService
{
    using System.Net;
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener tcpListener;
        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.tcpListener = new TcpListener(this.ipAddress, this.port);
        }

        public async Task Start()
        {
            this.tcpListener.Start();


            while (true)
            {

                var connection = await tcpListener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();
                var requestBody = await ReadRequest(networkStream);
                var requestText = HttpRequest.Parse(requestBody);

                await WriteResponse(networkStream);
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

        private async Task WriteResponse(NetworkStream networkStream)
        {
            string content = "<h1>Здравей, from the server!<h1>";
            int contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Server: WebServer
Date: {DateTime.UtcNow:r}
Content-Length: {contentLength}
Content-Type: text/html; charset=UTF-8

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);

        }
    }
}
