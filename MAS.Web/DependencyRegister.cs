using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MAS.Web
{
    public static class DependencyRegister
    {
        public static IServiceCollection RegisterDependencies( this IServiceCollection services)
        {
            services.AddScoped<Core.Interface.Application.Indent.IIendentService, Application.Indent.IndentService>();
            services.AddScoped<Core.Interface.Repository.Indent.IIendentRepositoryService,Repository.Indent.IndentRepositoryService>();
           
           

            return services;
        }
    }
}
