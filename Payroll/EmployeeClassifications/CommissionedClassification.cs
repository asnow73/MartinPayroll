using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class CommissionedClassification : PaymentClassification
    {
        private double salary;
        private double commissionedRate;

        public CommissionedClassification(double salary, double commissionedRate)
        {
            this.salary = salary;
            this.commissionedRate = commissionedRate;
        }

        public double Salary
        {
            get { return salary; }
        }

        public double CommissionedRate
        {
            get { return commissionedRate; }
        }
    }
}
