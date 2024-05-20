﻿using CC.WebAPIs.Infrastructure;

using System;

namespace CC.WebAPIs.Infrastructure
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler, string pattern = "")
        {
            builder.MapGet(pattern, handler)
                .WithName($"{handler.Method.DeclaringType?.Name}-{handler.Method.Name}");

            return builder;
        }

        public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler, string pattern = "")
        {
            builder.MapPost(pattern, handler)
                .WithName($"{handler.Method.DeclaringType?.Name}-{handler.Method.Name}");

            return builder;
        }

        public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, string pattern)
        {
            builder.MapPut(pattern, handler)
                .WithName($"{handler.Method.DeclaringType?.Name}-{handler.Method.Name}");

            return builder;
        }

        public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, string pattern)
        {
            builder.MapDelete(pattern, handler)
                .WithName($"{handler.Method.DeclaringType?.Name}-{handler.Method.Name}");

            return builder;
        }
    }
}
