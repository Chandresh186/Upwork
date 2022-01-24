using Nest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest { 

public class ElasticSearchRepository : IElasticSearchRepository {
    private readonly IElasticClient _elasticClient;

    public ElasticSearchRepository(IElasticClient elasticClient) {
        _elasticClient = elasticClient;
    }

    public Task AddOrUpdateAsync<T>(string indexName, T model) where T : class {
        throw new NotImplementedException();
    }

    public Task BulkAddAsync<T>(string indexName, IEnumerable<T> entries, int bulkNum = 1000) where T : class {
        return _elasticClient.BulkAsync(x => x
            .Index(indexName)
            .IndexMany(entries));
    }

    public Task BulkDeleteAsync<T>(string indexName, IEnumerable<T> list, int bulkNum = 1000) where T : class {
        throw new NotImplementedException();
    }

    public Task DeleteAsync<T>(string indexName, T model) where T : class {
        throw new NotImplementedException();
    }

    public Task DeleteIndexAsync(string indexName) {
        throw new NotImplementedException();
    }

    public Task ReBuild<T>(string indexName) where T : class {
        throw new NotImplementedException();
    }

    public Task ReIndex<T>(string indexName) where T : class {
        throw new NotImplementedException();
    }
}
}