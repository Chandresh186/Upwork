using Upwork.ElasticSearch_Net.Contacts.Properties;
using Upwork.ElasticSearch_Net.Contacts.Shared;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Properties;

namespace Upwork.ElasticSearch_Net.Application.Properties;

public class PropertyService : IPropertyService {
    private readonly IElasticSearchRepository _elasticSearchRepository;
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(
        IElasticSearchRepository elasticSearchRepository,
        IPropertyRepository propertyRepository
    ) {
        _elasticSearchRepository = elasticSearchRepository;
        _propertyRepository = propertyRepository;
    }

    public Task BulkUpload(IEnumerable<Property> properties) {
        return _elasticSearchRepository.BulkAddAsync(PropertyConsts.IndexName, properties);
    }

    public Task<IEnumerable<Property>> GetAll(SearchInput input) {
        return _propertyRepository.SearchProperties(input.SearchText, input.Markets);
    }
}
