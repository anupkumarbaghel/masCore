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
        }

        public long CreateIndent(Core.Domain.Indent.Indent indent)
        {
            _context.Indents.Add(indent);
            _context.SaveChanges();
            return indent.ID;
        }

        public long DeleteIndent(long ID)
        {
            Core.Domain.Indent.Indent indent = _context.Indents.SingleOrDefault(e => e.ID == ID);
            if (indent == null) return -1;

            _context.Indents.Remove(indent);
            _context.SaveChanges();
            return indent.ID;
        }

        public IEnumerable<Core.Domain.Indent.Indent> GetAllIndent()
        {
            return _context.Indents.ToList();
        }

        public Core.Domain.Indent.Indent GetIndent(int id)
        {
            return _context.Indents.SingleOrDefault(e => e.ID == id);
        }

        public Core.Domain.Indent.Indent GetIndentByStatus(string IndentStatus)
        {
            return _context.Indents.Include(e=>e.IndentTableCollection).SingleOrDefault(e => e.IndentStatus == IndentStatus);
        }

        public void UpdateIndent(Core.Domain.Indent.Indent indent)
        {
            _context.Entry(indent).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
