using WebServer.Http;

namespace WebServer.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse() :
            base(HttpStatusCode.NotFound)
        {
        }
    }
}