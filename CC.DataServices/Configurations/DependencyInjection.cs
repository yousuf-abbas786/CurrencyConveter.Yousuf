using CC.Shared.DbContext;

using CC.DataServices.ExtAPIs;
using CC.DataServices.MongoDB;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CC.DataServices.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoConnectionString>(configuration.GetSection("Databases:MongoDB"));
            services.Configure<mySQLConnectionString>(configuration.GetSection("Databases:mySQL"));
            //services.Configure<ExtAPIBaseURLs>(configuration.GetSection("APIBaseURLs"));

            #region Mongo Services
            services.AddSingleton<MongoDBContext>();

            services.AddSingleton<MatchServices>();
            #endregion

            #region External API Services
            services.AddSingleton<LiveKubeAPIServices>();
            #endregion

            #region mySQL Services
            #endregion

            return services;
        }
        // builder.Services.Configure<ExSettings>(builder.Configuration.GetSection("ExSettings:ConString"));
        //public class ExSettings
        //{
        //	public string ConString { get; set; }
        //}

        // private readonly ExSettings _settings;
        // constructor IOptions<ExSettings> settings
        // _settings = settings.Value N78176 358C 1
    }
}
