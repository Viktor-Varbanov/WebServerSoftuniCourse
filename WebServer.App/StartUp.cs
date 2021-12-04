using System.Threading.Tasks;
using WebServer.App.Controllers;
using WebServer.Responses;

namespace WebServer.App
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                    .MapGet("/", request => new HomeController(request).Index())
                    .MapGet("/Cats", request => new AnimalsController(request).Cats())
                    .MapGet("/Dogs", request => new AnimalsController(request).Dogs()))
                .Start();
    }
}