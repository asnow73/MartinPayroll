using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class DateUtil
    {
        static public bool IsInPayPeriod(DateTime theDate, DateTime startDate, DateTime endDate)
        {
            return (theDate >= startDate) && (theDate <= endDate);
        }
    }
}
