using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAS.Core.Domain.Indent;
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

        public Core.Domain.Indent.Indent CreateEditIndent(Core.Domain.Indent.Indent indent)
        {
            if (indent.ID > 0)
            {
                _context.Update(indent);
            }
            else
            {
                _context.Add(indent);
            }
           
            _context.SaveChanges();
            return indent;
        }
        public void DraftOpenIndent(long id)
        {

            _context.Database.ExecuteSqlCommand("usp_MakeDraftOpenIndent @p0", id);
            _context.SaveChanges();
            //plese take referenence from below
            //http://www.talkingdotnet.com/how-to-execute-stored-procedure-in-entity-framework-core/

        }

        public long DeleteIndent(long ID)
        {
            Core.Domain.Indent.Indent indent = _context.Indents.SingleOrDefault(e => e.ID == ID);
            if (indent == null) return -1;

            _context.Indents.Remove(indent);
            _context.SaveChanges();
            return indent.ID;
        }

        public IEnumerable<Core.Domain.Indent.Indent> GetAllIndentByStatus(string indentStatus)
        {
            return _context.Indents.Where(e=>e.IndentStatus==indentStatus).ToList();
        }

        public Core.Domain.Indent.Indent GetIndent(long id)
        {
            return _context.Indents.Include(e => e.IndentTableCollection).FirstOrDefault(e => e.ID == id);
        }

        public Core.Domain.Indent.Indent GetOpenIndent()
        {
            return _context.Indents.Include(e=>e.IndentTableCollection).SingleOrDefault(e => e.IndentStatus == "o");
        }

       
    }
}
