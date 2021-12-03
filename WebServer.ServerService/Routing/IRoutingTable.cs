namespace WebServer.ServerService.Routing
{
    using Http;

    public interface IRoutingTable
    {
        void Map(string url, HttpMethod httpMethod, HttpResponse response);

        void MapGet(string ulr, HttpResponse response);
    }
}
