using System.Collections.Generic;
using System.Threading.Tasks;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Contacts
{
    public interface IElasticSearchRepository
    {
        Task ReIndex<T>(string indexName) where T : class;
        Task AddOrUpdateAsync<T>(string indexName, T model) where T : class;
        Task BulkAddAsync<T>(string indexName, IEnumerable<T> entries, int bulkNum = 1000) where T : class;
        Task BulkDeleteAsync<T>(string indexName, IEnumerable<T> list, int bulkNum = 1000) where T : class;
        Task DeleteAsync<T>(string indexName, T model) where T : class;
        Task DeleteIndexAsync(string indexName);
        Task ReBuild<T>(string indexName) where T : class;
    }
}
