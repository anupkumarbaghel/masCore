using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAS.Core.Domain.Store.Indent;
using Microsoft.EntityFrameworkCore;

namespace MAS.Repository.Indent
{
    public class IndentRepositoryService:Core.Interface.Repository.Indent.IIendentRepositoryService
    {
        MASDBContext _context;
        public IndentRepositoryService(MASDBContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Core.Domain.Store.Indent.Indent CreateEditIndent(Core.Domain.Store.Indent.Indent indent)
        {
            if (indent.ID > 0)
            {
                _context.Update(indent);
            }
            else
            {
                _context.Add(indent);
            }
            foreach (var indentTable in indent.IndentTableCollection)
            {
                if (indentTable.IsDelete)
                {
                    indent.IndentTableCollection.Remove(indentTable);
                }
            }
                foreach (var indentTable in indent.IndentTableCollection)
            {
                
                MAS.Core.Domain.Store.MasterRegister.MasterRegister masterregister = indentTable.MasterRegister;
                _context.Entry(masterregister).State = EntityState.Unchanged;
            }
            _context.SaveChanges();
            return indent;
        }
        public void DraftOpenIndent(Core.Domain.Store.Indent.Indent indent)
        {

            _context.Database.ExecuteSqlCommand("[dbo].[usp_MakeDraftOpenIndent] @p0,@p1", indent.ID,indent.StoreID);
            _context.SaveChanges();
            //plese take referenence from below
            //http://www.talkingdotnet.com/how-to-execute-stored-procedure-in-entity-framework-core/

        }

        public long DeleteIndent(long ID)
        {
            Core.Domain.Store.Indent.Indent indent = _context.Indents.SingleOrDefault(e => e.ID == ID);
            if (indent == null) return -1;

            _context.Indents.Remove(indent);
            _context.SaveChanges();
            return indent.ID;
        }

        public IEnumerable<Core.Domain.Store.Indent.Indent> GetAllIndentByStatus(string indentStatus,int storeID)
        {
            return _context.Indents
                .Where(e=>e.IndentStatus==indentStatus && e.StoreID==storeID).ToList();
        }
        public IEnumerable<Core.Domain.Store.Indent.Indent> GetAllIndentExcelReport(Core.DTO.DTOExcelReportInput excelInputModel)
        {
            return _context.Indents.Include(e => e.IndentTableCollection)
                 .ThenInclude(f => f.MasterRegister)
                .Where(e => e.IndentStatus == "s" 
                && e.StoreID == excelInputModel.StoreID
                && e.SubmittedDate>=excelInputModel.StartDate
                && e.SubmittedDate<=excelInputModel.EndDate).ToList();
        }
        
        public Core.Domain.Store.Indent.Indent GetIndent(long id)
        {
            return _context.Indents.Include(e => e.IndentTableCollection)
                .ThenInclude(f => f.MasterRegister)
                .FirstOrDefault(e => e.ID == id);
        }

        public Core.Domain.Store.Indent.Indent GetOpenIndent(int storeID)
        {
            return _context.Indents.Include(e=>e.IndentTableCollection)
                .ThenInclude(f=>f.MasterRegister)
                .FirstOrDefault(e => e.IndentStatus == "o" && e.StoreID==storeID);
        }

       
    }
}
