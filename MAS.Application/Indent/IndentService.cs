using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Store.Indent;
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

        public Core.Domain.Store.Indent.Indent CreateEditIndent(Core.Domain.Store.Indent.Indent indent)
        {
            return _IndentService.CreateEditIndent(indent);
        }
        public void DraftOpenIndent(Core.Domain.Store.Indent.Indent indent)
        {
           _IndentService.DraftOpenIndent(indent);
        }

        public long DeleteIndent(long ID)
        {
            return _IndentService.DeleteIndent(ID);
        }

        public IEnumerable<Core.Domain.Store.Indent.Indent> GetAllIndentByStatus(string indentStatus,int storeID,bool isSitework)
        {
            return _IndentService.GetAllIndentByStatus(indentStatus,storeID,isSitework);
        }

        public Core.Domain.Store.Indent.Indent GetIndent(long id)
        {
            return _IndentService.GetIndent(id);
        }

        public Core.Domain.Store.Indent.Indent GetOpenIndent(int storeID,bool isSitework)
        {
            return _IndentService.GetOpenIndent(storeID,isSitework);
        }

        
    }
}
