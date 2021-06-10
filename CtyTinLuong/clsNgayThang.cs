using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtyTinLuong
{
    public partial class clsNgayThang : clsDBInteractionBase
    {
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
        public static DateTime GetFirstDayInYear(int year)
        {
            DateTime aDateTime = new DateTime(year, 1, 1);
            return aDateTime;
        }
    }
}
