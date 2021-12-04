using WebServer.Controllers;
using WebServer.Http;
using WebServer.Responses;

namespace WebServer.App.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index() => Text("Hello from Viktor!");

        public HomeController(HttpRequest httpRequest)
            : base(httpRequest)
        {
        }

        public HttpResponse RedirectToYoutube() => Redirect("https://www.youtube.com/");
    }
}