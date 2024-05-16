﻿using CC.WebAPIs.Endpoints;

using System.Reflection;

namespace CC.WebAPIs.Infrastructure
{
    public static class EndpointRouting
    {
        public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
        {
            var groupName = group.GetType().Name;

            return app
                .MapGroup($"/api/{groupName}")
                .WithGroupName("v1")
                .WithTags(groupName)
                .AddEndpointFilter<EndpointExceptionFilter>()
                .WithOpenApi();
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            var endpointGroupType = typeof(EndpointGroupBase);

            var assembly = Assembly.GetExecutingAssembly();

            var endpointGroupTypes = assembly.GetExportedTypes()
                .Where(t => t.IsSubclassOf(endpointGroupType));

            foreach (var type in endpointGroupTypes)
            {
                if (Activator.CreateInstance(type) is EndpointGroupBase instance)
                {
                    instance.Map(app);
                }
            }

            return app;
        }
    }
}
