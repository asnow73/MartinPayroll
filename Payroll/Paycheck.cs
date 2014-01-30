using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class Paycheck
    {
        private DateTime payDate;
        private DateTime payPeriodStartDate;

        private double grossPay;
        private double deductions;
        private double netPay;

        public Paycheck(DateTime payPeriodStartDate, DateTime payPeriodEndDate)
        {
            this.payPeriodStartDate = payPeriodStartDate;
            this.payDate = payPeriodEndDate;
        }

        public DateTime PayDate
        {
            get { return payDate; }
        }

        public double GrossPay
        {
            get { return grossPay; }
            set { grossPay = value; }
        }

        public double Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        public double NetPay
        {
            get { return netPay; }
            set { netPay = value; }
        }

        public DateTime PayPeriodStartDate
        {
            get { return payPeriodStartDate; }
        }

        public DateTime PayPeriodEndDate
        {
            get { return payDate; }
        }
    }
}
