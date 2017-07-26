using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.Indent
{
    public interface IIendentRepositoryService
    {
        IEnumerable<Domain.Indent.Indent> GetAllIndent();
        Domain.Indent.Indent GetIndent(int id);
        Domain.Indent.Indent GetIndentByStatus(string IndentStatus);
        long CreateIndent(Domain.Indent.Indent indent);
        long DeleteIndent(long ID);
        void UpdateIndent(Domain.Indent.Indent indent);
    }
}
