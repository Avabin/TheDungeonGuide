using Microsoft.Extensions.DependencyInjection;
using Mongo.DataService;
using Mongo.DataSource;
using Mongo.Options;

namespace Mongo;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, Action<MongoSettings> configure)
    {
        services.AddOptions().Configure(configure);
        services.AddTransient(typeof(IMongoDataSource<>), typeof(MongoDataSource<>));
        services.AddTransient(typeof(IDataService<,,,>), typeof(DataService<,,,>));
        
        return services;
    }
}