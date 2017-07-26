using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.Indent
{
    public interface IIendentTableRepositoryService
    {
        IEnumerable<Domain.Indent.IndentTable> GetAllIndentTable();
        Domain.Indent.IndentTable GetIndentTable(int id);
        long CreateIndentTable(Domain.Indent.IndentTable indent);
        long DeleteIndentTable(long ID);
        void UpdateIndentTable(Domain.Indent.IndentTable indent);
    }
}
