using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Indent;
using MAS.Core.Interface.Repository.Indent;



namespace MAS.Application.Indent
{
    public class IndentService :MAS.Core.Interface.Application.Indent.IIendentService
    {
        IIendentRepositoryService _IndentService;
        public IndentService(IIendentRepositoryService indentService)
        {
            _IndentService = indentService;
        }

        public long CreateIndent(Core.Domain.Indent.Indent indent)
        {
            return _IndentService.CreateIndent(indent);
        }

        public long DeleteIndent(long ID)
        {
            return _IndentService.DeleteIndent(ID);
        }

        public IEnumerable<Core.Domain.Indent.Indent> GetAllIndent()
        {
            return _IndentService.GetAllIndent();
        }

        public Core.Domain.Indent.Indent GetIndent(int id)
        {
            return _IndentService.GetIndent(id);
        }

        public void UpdateIndent(Core.Domain.Indent.Indent indent)
        {
            _IndentService.UpdateIndent(indent);
        }
    }
}
