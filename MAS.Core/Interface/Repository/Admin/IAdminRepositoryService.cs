using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.Admin
{
    public interface IAdminRepositoryService
    {
        Domain.Admin.Admin PostAdmin(Domain.Admin.Admin admin);
    }
}
