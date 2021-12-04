using System.Text;
using WebServer.ServerService.Common;
using WebServer.ServerService.Http;

namespace WebServer.ServerService.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string content, string contentType) :
            base(HttpStatusCode.Ok)
        {
            Guard.AgainstNull(content);
            var contentLength = Encoding.UTF8.GetByteCount(content).ToString();

            Headers.Add("Content-Type", contentType);
            Headers.Add("Content-Length", contentLength);

            this.Content = content;
        }
    }
}