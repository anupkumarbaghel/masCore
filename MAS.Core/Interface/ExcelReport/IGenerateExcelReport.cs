using MAS.Core.Domain.Store.MasterRegister;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MAS.Core.Domain.Store.Indent;
using MAS.Core.Domain.Store.MeasurementBook;

namespace MAS.Core.Interface.ExcelReport
{
    public interface IGenerateExcelReport
    {
        MemoryStream GenerateExcelReport(List<MasterRegister> masterRegister, IEnumerable<Indent> indents, IEnumerable<MeasurementBook> mbs);
    }
}
