using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class TimeCard
    {
        private DateTime date;
        private double hours;

        public TimeCard(DateTime dt, double hours)
        {
            this.date = dt;
            this.hours = hours;
        }

        public double Hours
        {
            get { return this.hours; }
        }

        public DateTime Date
        {
            get { return this.date; }
        }
    }
}
