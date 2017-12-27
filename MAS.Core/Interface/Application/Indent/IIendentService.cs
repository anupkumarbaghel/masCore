using System;
using System.Collections.Generic;
using System.Text;


namespace MAS.Core.Interface.Application.Indent
{
    public interface IIendentService
    {
        IEnumerable<Domain.Store.Indent.Indent> GetAllIndentByStatus(string indentStatus,int storeID,bool isSitework);
        Domain.Store.Indent.Indent GetIndent(long id);
        Domain.Store.Indent.Indent GetOpenIndent(int storeID,bool isSitework);
        Domain.Store.Indent.Indent CreateEditIndent(Domain.Store.Indent.Indent indent);
        void DraftOpenIndent(Domain.Store.Indent.Indent indent);
        long DeleteIndent(long ID);
       
    }
}
