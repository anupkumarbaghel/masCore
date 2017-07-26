using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Indent;
using MAS.Core.Interface.Repository.Indent;



namespace MAS.Application.Indent
{
    public class IndentTableService :MAS.Core.Interface.Application.Indent.IIndentTableAppService
    {
        IIendentTableRepositoryService _IndentTableService;
        public IndentTableService(IIendentTableRepositoryService indentTableService)
        {
            _IndentTableService = indentTableService;
        }

        public long CreateIndentTable(IndentTable indentTable)
        {
            if (indentTable.ID > 0)
            {
                UpdateIndentTable(indentTable);
                return indentTable.ID;
            }
            return _IndentTableService.CreateIndentTable(indentTable);
        }

        public long DeleteIndentTable(long ID)
        {
            return _IndentTableService.DeleteIndentTable(ID);
        }

        public IEnumerable<IndentTable> GetAllIndentTable()
        {
            return _IndentTableService.GetAllIndentTable();
        }

        public IndentTable GetIndentTable(int id)
        {
            return _IndentTableService.GetIndentTable(id);
        }

        public void UpdateIndentTable(IndentTable indent)
        {
            _IndentTableService.UpdateIndentTable(indent);
        }
    }
}
