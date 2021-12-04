using WebServer.Http;

namespace WebServer.Responses
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location) : base(HttpStatusCode.Found)
        {
            Headers.Add("Location", location);
        }
    }
}