using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class SalesReceipt
    {
        private double amount;
        private DateTime date;

        public SalesReceipt(DateTime date, double amount)
        {
            this.amount = amount;
            this.date = date;
        }

        public double Amount
        {
            get { return this.amount; }
        }

        public DateTime Date
        {
            get { return this.date; }
        }
    }
}
