using System;
using Microsoft.AspNetCore.Builder;

namespace ApiExpansion
{
    public class ServiceLocator
    {
        public static IServiceProvider Instance;
    }

    public static class ServiceLocatorExpansion
    {
        public static IApplicationBuilder InitServiceLocator(this IApplicationBuilder builder)
        {
            ServiceLocator.Instance = builder.ApplicationServices;
            return builder;
        }
    }
}