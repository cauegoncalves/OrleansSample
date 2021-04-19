using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace cgds.Bank.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddBankApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions));
            return services;
        }

    }
}
