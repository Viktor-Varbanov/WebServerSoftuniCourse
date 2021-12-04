using WebServer.Http;
using WebServer.Responses;

namespace WebServer.Controllers
{
    public abstract class Controller
    {
        protected HttpRequest HttpRequest { get; set; }

        protected Controller(HttpRequest httpRequest)
            => HttpRequest = httpRequest;

        protected HttpResponse Text(string text) => new TextResponse(text);

        protected HttpResponse Html(string html) => new HtmlResponse(html);

        protected HttpResponse Redirect(string location) => new RedirectResponse(location);
    }
}