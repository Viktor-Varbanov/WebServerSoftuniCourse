using WebServer.ServerService.Http;

namespace WebServer.ServerService.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse() :
            base(HttpStatusCode.NotFound)
        {
        }
    }
}