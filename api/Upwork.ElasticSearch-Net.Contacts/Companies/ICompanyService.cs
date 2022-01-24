using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.Contacts.Shared;

namespace Upwork.ElasticSearch_Net.Contacts.Companies
{
    public interface ICompanyService
    {
        public Task BulkUpload(IEnumerable<Company> companies);
        public Task<IEnumerable<Company>> GetAll(SearchInput input);
    }
}
