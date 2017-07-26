using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAS.Core.Domain.Indent;
using Microsoft.EntityFrameworkCore;

namespace MAS.Repository.Indent
{
    public class IndentTableRepositoryService:Core.Interface.Repository.Indent.IIendentTableRepositoryService
    {
        MASDBContext _context;
        public IndentTableRepositoryService(MASDBContext context)
        {
            _context = context;
        }

        public long CreateIndentTable(IndentTable indent)
        {
            _context.IndentTables.Add(indent);
            _context.SaveChanges();
            return indent.ID;
        }

        public long DeleteIndentTable(long ID)
        {
            Core.Domain.Indent.IndentTable indent = _context.IndentTables.SingleOrDefault(e => e.ID == ID);
            if (indent == null) return -1;

            _context.IndentTables.Remove(indent);
            _context.SaveChanges();
            return indent.ID;
        }

        public IEnumerable<IndentTable> GetAllIndentTable()
        {
            return _context.IndentTables.ToList();
        }

        public IndentTable GetIndentTable(int id)
        {
            return _context.IndentTables.SingleOrDefault(e => e.ID == id);
        }

        public void UpdateIndentTable(IndentTable indentTable)
        {
            _context.Entry(indentTable).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
