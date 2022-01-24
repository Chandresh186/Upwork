using Nest;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest
{

    public interface IElasticSearchIndexDefinition
    {
        public void CreateIndexIfNotExist(IElasticClient client);
    }
}
