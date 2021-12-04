using WebServer.ServerService.Http;

namespace WebServer.ServerService.Responses
{
    public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}