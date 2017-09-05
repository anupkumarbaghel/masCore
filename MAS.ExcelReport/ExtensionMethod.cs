using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.ExcelReport
{
    internal static class ExtensionMethod
    {
        private const string _dateFormat = "dd.MM.yyyy";
        public static string ToDate(this DateTime? datetime)
        {
            string result = string.Empty;
            if (datetime.HasValue)
            {
                result = Convert.ToDateTime(datetime).ToString(_dateFormat);
            }

            return result;
        }
        public static string ToDate(this DateTime datetime)
        {
            string result = string.Empty;
           
                result = Convert.ToDateTime(datetime).ToString(_dateFormat);
           

            return result;
        }
    }
}
