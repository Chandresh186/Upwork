using Microsoft.Extensions.DependencyInjection;
using Upwork.ElasticSearch_Net.Application.Companies;
using Upwork.ElasticSearch_Net.Application.Properties;
using Upwork.ElasticSearch_Net.Contacts.Companies;
using Upwork.ElasticSearch_Net.Contacts.Properties;

namespace Upwork.ElasticSearch_Net.Application;
public static class ApplicationExtensions {
    public static void AddApplicationServices(this IServiceCollection services) {
        services.AddTransient<IPropertyService, PropertyService>();
        services.AddTransient<ICompanyService, CompanyService>();
    }
}
