﻿
using CC.DataServices.Services;
using CC.DataServices.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CC.DataServices.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region External API Services
            services.AddSingleton<ICurrencyService, CurrencyService>();
            #endregion

            return services;
        }
    }
}
