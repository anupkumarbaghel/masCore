using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAS.Core.Domain.Admin;
using MAS.Core.Domain.Store.Indent;
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
            if (admin.ID > 0) _context.Update(admin);
            else _context.Add(admin);


            _context.SaveChanges();
            return admin;
        }

       
    }
}
