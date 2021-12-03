using System.Text;

namespace WebServer.ServerService.Http
{
    using System;
    public abstract class HttpResponse
    {
        protected HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            Headers.Add("Date", $"{DateTime.UtcNow:r}");
            Headers.Add("Server", "WebServer");
        }
        public HttpStatusCode StatusCode { get; private set; }

        public HttpHeaderCollection Headers { get; } = new();

        public string Content { get; set; }

        public override string ToString()
        {
            var response = new StringBuilder();

            response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in Headers)
            {
                response.Append(header);
            }

            response.AppendLine();

            response.AppendLine(this.Content);

            return response.ToString();
        }
    }
}
