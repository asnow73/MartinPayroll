using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class MonthlySchedule : PaymentSchedule
    {
        private bool IsLastDayOfMonth(DateTime date)
        {
            int m1 = date.Month;
            int m2 = date.AddDays(1).Month;
            return (m1 != m2);
        }

        public override bool IsPayDate(DateTime payDate)
        {
            return IsLastDayOfMonth(payDate);
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            int days = 0;
            while (date.AddDays(days - 1).Month == date.Month)
                days--;

            return date.AddDays(days);
        }
    }
}
