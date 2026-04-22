namespace WebApplication1.Extensions;

public static class ServiceCollectionExtensions
{
    public static void InjectEnvironmentClass( this IServiceCollection services, IConfiguration configuration)
    {
        Models.Environment environment = configuration
            .GetSection(nameof(Models.Environment))
            .Get<Models.Environment>() ?? throw new InvalidOperationException("Environment is missing");
        services.AddSingleton(environment);
    }
}
