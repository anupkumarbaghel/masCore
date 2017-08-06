using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAS.Core.Domain.Admin;
using MAS.Core.Domain.Indent;
using Microsoft.EntityFrameworkCore;

namespace MAS.Repository.Admin
{
    public class AdminRepositoryService:Core.Interface.Repository.Admin.IAdminRepositoryService
    {
        MASDBContext _context;
        public AdminRepositoryService(MASDBContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

       
        public Core.Domain.Admin.Admin PostAdmin(Core.Domain.Admin.Admin admin)
        {
            _context.Update(admin);
            _context.SaveChanges();
            return admin;
        }
    }
}
