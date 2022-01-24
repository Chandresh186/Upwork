using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Linq;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Companies;
using Upwork.ElasticSearch_Net.ElasticSearch.Contacts.Properties;
using Upwork.ElasticSearch_Net.ElasticSearch.Nest.Companies;
using Upwork.ElasticSearch_Net.ElasticSearch.Nest.Properties;

namespace Upwork.ElasticSearch_Net.ElasticSearch.Nest { 

public static class ElasticsearchExtensions {
    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration) {
        var url = configuration["ElasticSearch:Url"];
        var settings = new ConnectionSettings(new Uri(url));
        var client = new ElasticClient(settings);

        CreateIndexes(client);

        services.AddSingleton<IElasticClient>(client);

        services.AddSingleton<IElasticSearchRepository, ElasticSearchRepository>();
        services.AddSingleton<IPropertyRepository, PropertyRepository>();
        services.AddSingleton<ICompanyRepository, CompanyRepository>();
    }

    private static void CreateIndexes(IElasticClient client) {
        var type = typeof(IElasticSearchIndexDefinition);
        var types = typeof(ElasticsearchExtensions).Assembly.GetTypes()
            .Where(p => type.IsAssignableFrom(p) && p.IsClass);

        foreach (var typeDefinition in types) {
            var instance = (IElasticSearchIndexDefinition)Activator.CreateInstance(typeDefinition);
            instance.CreateIndexIfNotExist(client);
        }

        // This can be done for dependency injection as well
        // Every service can be added to a container based on a interface using reflection
        // This method can be optimized with the new source generators
    }
}
}