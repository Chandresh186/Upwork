using Upwork.ElasticSearch_Net.Contacts.Companies;
using Upwork.ElasticSearch_Net.Contacts.Shared;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Companies;

namespace Upwork.ElasticSearch_Net.Application.Companies;

public class CompanyService : ICompanyService {
    private readonly IElasticSearchRepository _elasticSearchRepository;
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(
        IElasticSearchRepository elasticSearchRepository,
        ICompanyRepository companyRepository
    ) {
        _elasticSearchRepository = elasticSearchRepository;
        _companyRepository = companyRepository;
    }

    public Task BulkUpload(IEnumerable<Company> companies) {
        return _elasticSearchRepository.BulkAddAsync(CompanyConsts.IndexName, companies);
    }

    public Task<IEnumerable<Company>> GetAll(SearchInput input) {
        return _companyRepository.SearchCompanies(input.SearchText, input.Markets);
    }
}
