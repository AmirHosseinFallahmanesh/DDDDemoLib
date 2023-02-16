using Microsoft.Extensions.Configuration;

namespace Lib.Infra.ElasticSearch
{
    public interface IElasticConfigurationService
    {
        ElasticConfiguration Get();
    }

    public class ElasticConfigurationService : IElasticConfigurationService
    {
        private readonly IConfiguration configuration;

        public ElasticConfigurationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public ElasticConfiguration Get()
        {
            return configuration.GetSection("Elastic").Get<ElasticConfiguration>();
        }
    }
}
