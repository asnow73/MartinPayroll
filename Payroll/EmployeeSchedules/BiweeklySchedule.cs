using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return payDate.DayOfWeek == DayOfWeek.Friday &&
                payDate.Day % 2 == 0;
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-13);
        }
    }
}
