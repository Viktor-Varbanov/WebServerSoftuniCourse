namespace WebServer.Server.Controllers
{
    using ServerService.Http;

    public class HomeController
    {
        public HttpResponse Index()
        {
            return new HttpResponse();
        }
    }
}
