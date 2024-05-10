public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Register the CosmosClient as a singleton
        services.AddSingleton<CosmosClient>(serviceProvider =>
        {
            string connectionString = Configuration["CosmosDb:ConnectionString"];
            return new CosmosClient(connectionString);
        });

        // Register your generic repositories
        services.AddScoped(typeof(IRepository<FirstEntity, string>), serviceProvider =>
        {
            var client = serviceProvider.GetRequiredService<CosmosClient>();
            return new Repository<FirstEntity, string>(client, "YourDatabaseName", "FirstEntityContainer");
        });

        services.AddScoped(typeof(IRepository<SecondEntity, int>), serviceProvider =>
        {
            var client = serviceProvider.GetRequiredService<CosmosClient>();
            return new Repository<SecondEntity, int>(client, "YourDatabaseName", "SecondEntityContainer");
        });

        // Add other services your application requires
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Application configuration code here...
    }
}