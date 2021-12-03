namespace WebServer.ServerService.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpHeaderCollection Headers { get; } = new();

        public string Content { get; set; }
    }
}
