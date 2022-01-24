using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.Contacts.Companies;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Companies
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> SearchCompanies(string? searchText, string[]? markets);
    }
}
