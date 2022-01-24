using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.Contacts.Properties;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Properties;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest.Properties
{

    public class PropertyRepository : IPropertyRepository
    {
        private readonly IElasticClient _elasticClient;

        public PropertyRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<IEnumerable<Property>> SearchProperties(string? searchText, string[]? markets)
        {
            var response = await _elasticClient.SearchAsync<Property>(x => x
                .Index(PropertyConsts.IndexName)
                .Query(q => q.Bool(b => b
                    .Must(q => q.MultiMatch(m => m
                        .Fields(f => f
                            .Field(p => p.Name)
                            .Field(p => p.StreetAddress)
                            .Field(p => p.Market)
                            .Field(p => p.City)
                            .Field(p => p.State)
                            .Field(p => p.FormerName))
                        .Query(searchText)
                        .Fuzziness(Fuzziness.EditDistance(2))))
                    .Filter(fq => fq.Terms(t => t.Field(f => f.Market).Terms(markets))))));

            return response.Documents;
        }
    }
}