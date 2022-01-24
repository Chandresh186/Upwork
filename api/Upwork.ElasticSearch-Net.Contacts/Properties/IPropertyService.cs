using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.Contacts.Shared;

namespace Upwork.ElasticSearch_Net.Contacts.Properties
{
    public interface IPropertyService
    {
        public Task BulkUpload(IEnumerable<Property> properties);
        public Task<IEnumerable<Property>> GetAll(SearchInput input);
    }
}
