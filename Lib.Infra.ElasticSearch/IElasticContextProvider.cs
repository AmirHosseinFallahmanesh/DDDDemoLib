using Nest;

namespace Lib.Infra.ElasticSearch
{
    public interface IElasticContextProvider
    {
        IElasticClient GetClient();
    }
}
