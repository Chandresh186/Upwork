using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.Contacts.Companies;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Companies;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest.Companies { 

public class CompanyRepository : ICompanyRepository {
    private readonly IElasticClient _elasticClient;

    public CompanyRepository(IElasticClient elasticClient) {
        _elasticClient = elasticClient;
    }

    public async Task<IEnumerable<Company>> SearchCompanies(string? searchText, string[]? markets) {
        var response = await _elasticClient.SearchAsync<Company>(x => x
            .Index(CompanyConsts.IndexName)
            .Query(q => q.Bool(b => b
                .Must(q => q.MultiMatch(m => m
                    .Fields(f => f
                        .Field(p => p.Name)
                        .Field(p => p.Market)
                        .Field(p => p.State))
                    .Query(searchText)
                    .Fuzziness(Fuzziness.EditDistance(2))))
                .Filter(fq => fq.Terms(t => t.Field(f => f.Market).Terms(markets))))));

        return response.Documents;
    }
}
}