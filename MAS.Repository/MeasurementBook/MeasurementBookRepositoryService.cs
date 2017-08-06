using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MAS.Repository.MeasurementBook
{
    public class MeasurementBookRepositoryService:Core.Interface.Repository.MeasurementBook.IMeasurementBookRepositoryService
    {
        MASDBContext _context;
        public MeasurementBookRepositoryService(MASDBContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Core.Domain.MeasurementBook.MeasurementBook CreateEditMeasurementBook(Core.Domain.MeasurementBook.MeasurementBook measurementBook)
        {
            if (measurementBook.ID > 0)
            {
                _context.Update(measurementBook);
            }
            else
            {
                _context.Add(measurementBook);
            }

            _context.SaveChanges();
            return measurementBook;
        }
        public void DraftOpenMeasurementBook(Core.Domain.MeasurementBook.MeasurementBook measurementBook)
        {

            _context.Database.ExecuteSqlCommand("[dbo].[usp_MakeDraftOpenMeasurementBook] @p0,@p1", measurementBook.ID,measurementBook.StoreID);
            _context.SaveChanges();
            //plese take referenence from below
            //http://www.talkingdotnet.com/how-to-execute-stored-procedure-in-entity-framework-core/

        }

        public long DeleteMeasurementBook(long ID)
        {
            Core.Domain.MeasurementBook.MeasurementBook measurementBook = _context.MeasurementBooks.FirstOrDefault(e => e.ID == ID);
            if (measurementBook == null) return -1;

            _context.Remove(measurementBook);
            _context.SaveChanges();
            return measurementBook.ID;
        }

        public IEnumerable<Core.Domain.MeasurementBook.MeasurementBook> GetAllMeasurementBookByStatus(string measurementBookStatus,int storeID)
        {
            return _context.MeasurementBooks.Where(e => e.MeasurementBookStatus == measurementBookStatus 
            && e.StoreID==storeID ).ToList();
        }

        public Core.Domain.MeasurementBook.MeasurementBook GetMeasurementBook(long id)
        {
            return _context.MeasurementBooks.Include(e => e.MBTable).FirstOrDefault(e => e.ID == id);
        }

        public Core.Domain.MeasurementBook.MeasurementBook GetOpenMeasurementBook(int storeID)
        {
            return _context.MeasurementBooks.Include(e => e.MBTable).SingleOrDefault(e => e.MeasurementBookStatus == "o" && e.StoreID== storeID);
        }

     
       
    }
}
