using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Application.Admin
{
    public interface IAdminApplicationService
    {
        Domain.Admin.Admin PostAdmin(Domain.Admin.Admin admin);
    }
}
