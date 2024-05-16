using CC.Shared.Abstractions;

using Flurl.Http.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CC.Shared.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFlurlClientCache>(sp => new FlurlClientCache()
                .Add("CalendarAPI", configuration["APIBaseURLs:CalendarAPI"])
                .Add("DispatchAPI", configuration["APIBaseURLs:DispatchAPI"])
                .Add("PlaywrightAPI", configuration["APIBaseURLs:PlaywrightAPI"]));

            return services;
        }
    }
}
