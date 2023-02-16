using Elasticsearch.Net;
using Nest;
using System;
using System.Linq;

namespace Lib.Infra.ElasticSearch
{
    public class ElasticContextProvider: IElasticContextProvider
    {
        private string connectionAddress = "http://localhost:9200/";
        private readonly IElasticConfigurationService configurationService;

        private IElasticClient Client { get; set; }


        public ElasticContextProvider(IElasticConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }
      public IElasticClient GetClient()
        {
            if (Client==null)
            {
                var hosts = configurationService.Get().Addresses ??
                    new[] { connectionAddress };

                if (hosts.Length>1)
                {
                    var connectionPool = new SniffingConnectionPool(hosts.Select(a => new Uri(a)));
                    var setting = new ConnectionSettings(connectionPool);
                    Client = new ElasticClient(setting);
                }
                else
                {
                    var setting = new ConnectionSettings(new Uri(hosts[0]));
                    Client = new ElasticClient(setting);
                }
            }
            return Client;
           


        }
    }
}
