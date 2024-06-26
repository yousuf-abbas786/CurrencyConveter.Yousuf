﻿using CC.Shared.Abstractions;
using CC.Shared.Helpers;

using Flurl.Http.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CC.Shared.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFlurlClientCache>(sp => new FlurlClientCache().Add("FrankfurterAPI", configuration["APIBaseURLs:FrankfurterAPI"]));
            services.AddSingleton<CacheHelper>();

            return services;
        }
    }
}
