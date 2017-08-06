using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Indent;
using MAS.Core.Interface.Repository.Indent;



namespace MAS.Application.Indent
{
    public class LockService :MAS.Core.Interface.Application.Indent.IIendentService
    {
        IIendentRepositoryService _IndentService;
        public LockService(IIendentRepositoryService indentService)
        {
            _IndentService = indentService;
        }

        public Core.Domain.Indent.Indent CreateEditIndent(Core.Domain.Indent.Indent indent)
        {
            return _IndentService.CreateEditIndent(indent);
        }
        public void DraftOpenIndent(Core.Domain.Indent.Indent indent)
        {
           _IndentService.DraftOpenIndent(indent);
        }

        public long DeleteIndent(long ID)
        {
            return _IndentService.DeleteIndent(ID);
        }

        public IEnumerable<Core.Domain.Indent.Indent> GetAllIndentByStatus(string indentStatus,int storeID)
        {
            return _IndentService.GetAllIndentByStatus(indentStatus,storeID);
        }

        public Core.Domain.Indent.Indent GetIndent(long id)
        {
            return _IndentService.GetIndent(id);
        }

        public Core.Domain.Indent.Indent GetOpenIndent(int storeID)
        {
            return _IndentService.GetOpenIndent(storeID);
        }

        
    }
}
