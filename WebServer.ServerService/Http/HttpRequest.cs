using System;
using System.Linq;
using System.Collections.Generic;

namespace WebServer.ServerService.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Url { get; set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; set; }

        public static HttpRequest Parse(string requestBody)
        {
            var lines = requestBody.Split(NewLine);

            var startLine = lines.First().Split(" ");
            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];

            var headerCollection = ParseHttpHeaderCollection(lines.Skip(1));

            var bodyLines = lines.Skip(headerCollection.Count + 2);
            var body = string.Join(NewLine, bodyLines);

            var parsedRequest = new HttpRequest()
            {
                Body = body,
                Headers = headerCollection,
                Method = method,
                Url = url
            };
            return parsedRequest;
        }

        private static HttpHeaderCollection ParseHttpHeaderCollection(IEnumerable<string> lines)
        {
            var headers = new HttpHeaderCollection();
            var headerLines = lines.Skip(1);
            foreach (var headerLine in headerLines)
            {
                if (headerLine != string.Empty)
                {
                    string[] headerParts = headerLine.Split(": ");
                    string name = headerParts[0];
                    string value = headerParts[1];
                    headers.Add(name, value);
                }
            }

            return headers;
        }

        private static HttpMethod ParseHttpMethod(string httpMethod)
        {
            switch (httpMethod.ToUpper())
            {
                case "GET":
                    return HttpMethod.Get;

                case "POST":
                    return HttpMethod.Post;

                case "PUT":
                    return HttpMethod.Put;

                case "DELETE":
                    return HttpMethod.Delete;

                default:
                    throw new ArgumentException("The method is not supported!");
            }
        }
    }
}