﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Core.Interface.Repository.MeasurementBook
{
    public interface IMeasurementBookRepositoryService
    {
        IEnumerable<Domain.MeasurementBook.MeasurementBook> GetAllMeasurementBookByStatus(string measurementBookStatus);
        Domain.MeasurementBook.MeasurementBook GetMeasurementBook(long id);
        Domain.MeasurementBook.MeasurementBook GetOpenMeasurementBook();
        Domain.MeasurementBook.MeasurementBook CreateEditMeasurementBook(Domain.MeasurementBook.MeasurementBook measurementBook);
        void DraftOpenMeasurementBook(long id);
        long DeleteMeasurementBook(long ID);
    }
}
