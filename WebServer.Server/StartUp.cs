using System.Threading.Tasks;
using WebServer.ServerService.Responses;

namespace WebServer.Server
{
    using System;
    using ServerService;
    public class StartUp
    {
        public static async Task Main()
        {
            var httpServer = new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from Ivo!")));
            await httpServer.Start();
        }
    }
}
