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
            services.AddScoped<MAS.Core.Interface.Application.Indent.IIendentService,MAS.Application.Indent.IndentService>();
            services.AddScoped<Core.Interface.Repository.Indent.IIendentRepositoryService,Repository.Indent.IndentRepositoryService>();

            services.AddScoped<MAS.Core.Interface.Application.MeasurementBook.IMeasurementBookApplicationService, MAS.Application.MeasurementBook.MeasurementBookApplicationService>();
            services.AddScoped<Core.Interface.Repository.MeasurementBook.IMeasurementBookRepositoryService, Repository.MeasurementBook.MeasurementBookRepositoryService>();



            return services;
        }
    }
}
