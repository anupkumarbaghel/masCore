using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Application.MeasurementBook
{
    public interface IMeasurementBookApplicationService
    {
        IEnumerable<Domain.MeasurementBook.MeasurementBook> GetAllMeasurementBookByStatus(string measurementBookStatus,int storeID);
        Domain.MeasurementBook.MeasurementBook GetMeasurementBook(long id);
        Domain.MeasurementBook.MeasurementBook GetOpenMeasurementBook(int storeID);
        Domain.MeasurementBook.MeasurementBook CreateEditMeasurementBook(Domain.MeasurementBook.MeasurementBook measurementBook);
        void DraftOpenMeasurementBook(Domain.MeasurementBook.MeasurementBook measurementBook);
        long DeleteMeasurementBook(long ID);
    }
}
