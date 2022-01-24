using System.Collections.Generic;
using System.Threading.Tasks;
using Upwork.ElasticSearch_Net.Contacts.Properties;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Properties
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> SearchProperties(string? searchText, string[]? markets);
    }
}
