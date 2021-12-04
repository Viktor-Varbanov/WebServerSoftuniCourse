using System.Threading.Tasks;
using WebServer.ServerService;
using WebServer.ServerService.Responses;

namespace WebServer.Server
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                    .MapGet("/", new TextResponse("Hello from Ivo!"))
                    .MapGet("/Cats", new HtmlResponse("<h1>Hello from the cats!</h1>"))
                    .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>")))
                .Start();
    }
}