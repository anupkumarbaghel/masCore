using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.Indent
{
    public interface IIendentRepositoryService
    {
        IEnumerable<Domain.Indent.Indent> GetAllIndent();
        Domain.Indent.Indent GetIndent(int id);
        long CreateIndent(Domain.Indent.Indent indent);
        long DeleteIndent(long ID);
        void UpdateIndent(Domain.Indent.Indent indent);
    }
}
