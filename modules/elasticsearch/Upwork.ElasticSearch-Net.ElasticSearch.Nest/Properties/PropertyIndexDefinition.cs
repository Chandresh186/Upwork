using Nest;
using Upwork.ElasticSearch_Net.Contacts.Properties;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Properties;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest.Properties { 

public class PropertyIndexDefinition : IElasticSearchIndexDefinition {
    public void CreateIndexIfNotExist(IElasticClient client) {
        var indexExist = client.Indices.Exists(PropertyConsts.IndexName);

        if (indexExist.Exists) return;

        client.Indices.Create(PropertyConsts.IndexName, x => x
            .Settings(s => s
                .NumberOfShards(1)
                .NumberOfReplicas(0))
            .Map<Property>(y => y
                .AutoMap()
                .Properties(p => p
                    .Keyword(k => k.Name(n => n.Market)))));

        // INDEX IMPROVEMENTS
        // I could index only the fields that are indexed and only include other fields
        // Make market a keyword instead of text if you don't want to search for that only filter
        // Change the similarity model to some of the fields like state -> boolean, etc
        // A lot of these depend on the user behavior
        // Basic setting satisfy the assignment requirements

    }
}
}