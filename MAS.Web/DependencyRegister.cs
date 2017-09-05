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
            services.AddScoped<MAS.Core.Interface.Application.Indent.IIendentService,MAS.Application.Indent.LockService>();
            services.AddScoped<Core.Interface.Repository.Indent.IIendentRepositoryService,Repository.Indent.IndentRepositoryService>();

            services.AddScoped<MAS.Core.Interface.Application.MeasurementBook.IMeasurementBookApplicationService, MAS.Application.MeasurementBook.MeasurementBookApplicationService>();
            services.AddScoped<Core.Interface.Repository.MeasurementBook.IMeasurementBookRepositoryService, Repository.MeasurementBook.MeasurementBookRepositoryService>();

            services.AddScoped<MAS.Core.Interface.Application.Lock.ILockApplicationService, MAS.Application.Lock.LockApplicationService>();
            services.AddScoped<Core.Interface.Repository.Lock.ILockRepositoryService, Repository.Lock.LockRepositoryService>();

            services.AddScoped<MAS.Core.Interface.Application.Admin.IAdminApplicationService, MAS.Application.Admin.AdminApplicationService>();
            services.AddScoped<Core.Interface.Repository.Admin.IAdminRepositoryService, Repository.Admin.AdminRepositoryService>();

            services.AddScoped<MAS.Core.Interface.Application.MasterRegister.IMasterRegisterApplicationService, MAS.Application.MasterRegister.MasterRegisterApplicationService>();
            services.AddScoped<Core.Interface.Repository.MasterRegister.IMasterRegisterRepositoryService, Repository.MasterRegister.MasterRegisterRepositoryService>();

            services.AddScoped<MAS.Core.Interface.Application.ExcelReport.IGenerateExcelReportApplication, MAS.Application.ExcelReport.GenerateExcelReportApplication>();
            services.AddScoped<Core.Interface.ExcelReport.IGenerateExcelReport,MAS.ExcelReport.GenerateExcelReport>();



            return services;
        }
    }
}
