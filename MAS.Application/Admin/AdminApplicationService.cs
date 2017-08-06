using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Admin;
using MAS.Core.Domain.Indent;
using MAS.Core.Interface.Repository.Admin;



namespace MAS.Application.Admin
{
    public class AdminApplicationService :MAS.Core.Interface.Application.Admin.IAdminApplicationService
    {
        IAdminRepositoryService _AdminRepositoryService;
        public AdminApplicationService(IAdminRepositoryService adminRepositoryService)
        {
            _AdminRepositoryService = adminRepositoryService;
        }

      
        public Core.Domain.Admin.Admin PostAdmin(Core.Domain.Admin.Admin admin)
        {
            return _AdminRepositoryService.PostAdmin(admin);
        }
    }
}
