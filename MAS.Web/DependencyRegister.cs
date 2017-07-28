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
            services.AddScoped<Core.Interface.Application.Indent.IIndentTableAppService, Application.Indent.IndentTableService>();
            services.AddScoped<Core.Interface.Repository.Indent.IIendentTableRepositoryService, Repository.Indent.IndentTableRepositoryService>();
           

            return services;
        }
    }
}
