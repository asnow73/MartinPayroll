using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private double rate;
        private double salary;

        public ChangeCommissionedTransaction(int id, double salary, double rate)
            : base(id)
        {
            this.salary = salary;
            this.rate = rate;
        }

        protected override PaymentClassification Classification
        {
            get { return new CommissionedClassification(salary, rate); }
        }

        protected override PaymentSchedule Schedule
        {
            get { return new BiweeklySchedule(); }
        }
    }
}
