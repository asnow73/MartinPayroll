using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class CommissionedClassification : PaymentClassification
    {
        private Hashtable salesRecepts;
        private double salary;
        private double commissionedRate;

        public CommissionedClassification(double salary, double commissionedRate)
        {
            this.salary = salary;
            this.commissionedRate = commissionedRate;
            this.salesRecepts = new Hashtable();
        }

        public double Salary
        {
            get { return salary; }
        }

        public double CommissionedRate
        {
            get { return commissionedRate; }
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            salesRecepts[salesReceipt.Date] = salesReceipt;
        }

        public SalesReceipt GetSalesReceipt(DateTime date)
        {
            return (salesRecepts[date] as SalesReceipt);
        }
    }
}
