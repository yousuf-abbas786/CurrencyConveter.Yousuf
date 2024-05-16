
using CC.DataServices.ExtAPIs;
using CC.DataServices.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CC.DataServices.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {

            #region External API Services
            services.AddSingleton<ICurrencyService, CurrencyService>();
            #endregion

            return services;
        }
    }
}
