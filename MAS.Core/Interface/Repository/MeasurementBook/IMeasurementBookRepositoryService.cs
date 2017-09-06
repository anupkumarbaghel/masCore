using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.MeasurementBook
{
    public interface IMeasurementBookRepositoryService
    {
        IEnumerable<Domain.Store.MeasurementBook.MeasurementBook> 
            GetAllMeasurementBookByStatus(string measurementBookStatus,int storeID);
        IEnumerable<Domain.Store.MeasurementBook.MeasurementBook>
           GetAllMeasurementForExcelReport(DTO.DTOExcelReportInput excelReportInput);
        Domain.Store.MeasurementBook.MeasurementBook GetMeasurementBook(long id);
        Domain.Store.MeasurementBook.MeasurementBook GetOpenMeasurementBook(int storeID);
        Domain.Store.MeasurementBook.MeasurementBook CreateEditMeasurementBook(Domain.Store.MeasurementBook.MeasurementBook measurementBook);
        void DraftOpenMeasurementBook(Domain.Store.MeasurementBook.MeasurementBook measurementBook);
        long DeleteMeasurementBook(long ID);
    }
}
