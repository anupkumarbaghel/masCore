using System;
using System.Collections.Generic;
using System.Text;
using MAS.Core.Domain.Store.MeasurementBook;
using MAS.Core.Interface.Repository.MeasurementBook;

namespace MAS.Application.MeasurementBook
{
    public  class MeasurementBookApplicationService : MAS.Core.Interface.Application.MeasurementBook.IMeasurementBookApplicationService
    {

        IMeasurementBookRepositoryService _MeasurementBookService;
        public MeasurementBookApplicationService(IMeasurementBookRepositoryService measurementBookService)
        {
            _MeasurementBookService = measurementBookService;
        }

        public Core.Domain.Store.MeasurementBook.MeasurementBook CreateEditMeasurementBook(Core.Domain.Store.MeasurementBook.MeasurementBook measurementBook)
        {
            return _MeasurementBookService.CreateEditMeasurementBook(measurementBook);
        }

        public long DeleteMeasurementBook(long ID)
        {
            return _MeasurementBookService.DeleteMeasurementBook(ID);
        }

        public void DraftOpenMeasurementBook(Core.Domain.Store.MeasurementBook.MeasurementBook measurementBook)
        {
            _MeasurementBookService.DraftOpenMeasurementBook(measurementBook);
        }

        public IEnumerable<Core.Domain.Store.MeasurementBook.MeasurementBook> GetAllMeasurementBookByStatus(string measurementBookStatus,int storeID)
        {
            return _MeasurementBookService.GetAllMeasurementBookByStatus(measurementBookStatus,storeID);
        }

        public Core.Domain.Store.MeasurementBook.MeasurementBook GetMeasurementBook(long id)
        {
            return _MeasurementBookService.GetMeasurementBook(id);
        }

        public Core.Domain.Store.MeasurementBook.MeasurementBook GetOpenMeasurementBook(int storeID)
        {
            return _MeasurementBookService.GetOpenMeasurementBook(storeID);
        }
    }
}
