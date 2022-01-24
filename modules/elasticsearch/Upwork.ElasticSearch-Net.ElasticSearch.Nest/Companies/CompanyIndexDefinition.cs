using Nest;
using Upwork.ElasticSearch_Net.Contacts.Companies;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Companies;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest.Companies { 

public class CompanyIndexDefinition : IElasticSearchIndexDefinition {
    public void CreateIndexIfNotExist(IElasticClient client) {
        var indexExist = client.Indices.Exists(CompanyConsts.IndexName);

        if (indexExist.Exists) return;

        client.Indices.Create(CompanyConsts.IndexName, x => x
            .Settings(s => s
                .NumberOfShards(1)
                .NumberOfReplicas(0))
            .Map<Company>(y => y
                .AutoMap()
                .Properties(p => p
                    .Keyword(k => k.Name(n => n.Market)))));

        // I could index only the fields that are indexed and only include other fields
        // Check PropertyIndexDefinition.cs for more info
    }
}
}