﻿using Application;
using Microsoft.Extensions.DependencyInjection;

namespace User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(AssemblyReference.Assembly); });
        return services;
    }
}