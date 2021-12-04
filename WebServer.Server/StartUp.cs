using System.Threading.Tasks;
using WebServer.ServerService;
using WebServer.ServerService.Responses;

namespace WebServer.Server
{
    public class StartUp
    {
        public static async Task Main()
        {
            var httpServer = new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from Ivo!"))
                .MapGet("/Cats", new TextResponse("Hello from the cats!")));
            await httpServer.Start();
        }
    }
}