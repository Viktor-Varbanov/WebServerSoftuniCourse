using System.Collections;
using System.Collections.Generic;

namespace WebServer.Http
{
    public class HttpHeaderCollection : IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> _headers;

        public HttpHeaderCollection()
        {
            _headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(string name, string value)
        {
            var header = new HttpHeader(name, value);

            _headers.Add(name, header);
        }

        public int Count => _headers.Count;

        public IEnumerator<HttpHeader> GetEnumerator() => _headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}