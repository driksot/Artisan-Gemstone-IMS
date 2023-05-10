﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArtisanGemstoneIMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
