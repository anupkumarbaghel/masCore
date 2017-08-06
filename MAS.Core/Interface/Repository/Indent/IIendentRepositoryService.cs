using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.Indent
{
    public interface IIendentRepositoryService
    {
        IEnumerable<Domain.Indent.Indent> GetAllIndentByStatus(string indentStatus,int storeID);
        Domain.Indent.Indent GetIndent(long id);
        Domain.Indent.Indent GetOpenIndent(int storeID);
        Domain.Indent.Indent CreateEditIndent(Domain.Indent.Indent indent);
        void DraftOpenIndent(Domain.Indent.Indent indent);
        long DeleteIndent(long ID);
       
    }
}
