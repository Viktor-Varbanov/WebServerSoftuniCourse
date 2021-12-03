using System.Threading.Tasks;

namespace WebServer.Server
{
    using System;
    using ServerService;
    public class StartUp
    {
        public static async Task Main()
        {
            var httpServer = new HttpServer("127.0.0.1", 8081);
            await httpServer.Start();
        }
    }
}
