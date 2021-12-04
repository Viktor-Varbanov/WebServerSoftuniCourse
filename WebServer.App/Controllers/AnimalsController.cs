using WebServer.Controllers;
using WebServer.Http;
using WebServer.Responses;

namespace WebServer.App.Controllers
{
    public class AnimalsController : Controller
    {
        public HttpResponse Cats()
        {
            var query = HttpRequest.Query;

            var catName = query.ContainsKey("Name")
                ? query["Name"]
                : "the cats";
            var result = $"<h1> Hello from {catName}!</h1>";

            return Html(result);
        }

        public HttpResponse Dogs() => Html("<h1>Hello from the dogs!</h1>");

        public AnimalsController(HttpRequest httpRequest) : base(httpRequest)
        {
        }
    }
}