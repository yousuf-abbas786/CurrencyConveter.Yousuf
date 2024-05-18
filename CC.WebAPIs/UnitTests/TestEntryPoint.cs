using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Flurl.Http;
using CC.DataServices.Services;
using Flurl.Http.Configuration;

namespace CC.WebAPIs.UnitTests
{
    public class TestEntryPoint
    {
        public void Configure(WebApplication app)
        {
            app.MapGet("/test", () => "This is a test endpoint.");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IFlurlClientFactory, DefaultFlurlClientFactory>();
            services.AddSingleton<CurrencyService>();
        }
    }


}
