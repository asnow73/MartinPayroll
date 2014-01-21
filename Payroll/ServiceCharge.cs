using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ServiceCharge
    {
        private double amount;
        private DateTime time;

        public ServiceCharge(DateTime time, double charge)
        {
            this.time = time;
            this.amount = charge;
        }

        public double Amount
        {
            get { return amount; }
        }

        public DateTime Date
        {
            get { return time; }
        }
    }
}
