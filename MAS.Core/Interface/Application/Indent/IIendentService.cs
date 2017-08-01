using System;
using System.Collections.Generic;
using System.Text;


namespace MAS.Core.Interface.Application.Indent
{
    public interface IIendentService
    {
        IEnumerable<Domain.Indent.Indent> GetAllIndentByStatus(string indentStatus);
        Domain.Indent.Indent GetIndent(long id);
        Domain.Indent.Indent GetOpenIndent();
        Domain.Indent.Indent CreateEditIndent(Domain.Indent.Indent indent);
        void DraftOpenIndent(long id);
        long DeleteIndent(long ID);
       
    }
}
