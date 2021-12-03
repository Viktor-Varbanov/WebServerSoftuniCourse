using System.Collections.Generic;

namespace WebServer.ServerService.Http
{
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;


        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (!headers.ContainsKey(header.Name))
            {
                headers.Add(header.Name, header);
            }
        }

        public int Count => headers.Count;
    }
}
