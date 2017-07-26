using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Application.Indent
{
    public interface IIndentTableAppService
    {
        IEnumerable<Domain.Indent.IndentTable> GetAllIndentTable();
        Domain.Indent.IndentTable GetIndentTable(int id);
        long CreateIndentTable(Domain.Indent.IndentTable indentTable);
        long DeleteIndentTable(long ID);
        void UpdateIndentTable(Domain.Indent.IndentTable indent);
    }
}
