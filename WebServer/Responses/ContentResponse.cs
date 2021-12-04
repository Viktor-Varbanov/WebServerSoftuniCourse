using System.Text;
using WebServer.Common;
using WebServer.Http;

namespace WebServer.Responses
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