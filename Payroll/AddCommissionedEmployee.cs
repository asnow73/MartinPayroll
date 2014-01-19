using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
        private double salary;
        private double commissionedRate;

        public AddCommissionedEmployee(int empid, string name, string address, double salary, double commissionedRate)
            : base( empid, name, address)
        {
            this.salary = salary;
            this.commissionedRate = commissionedRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new CommissionedClassification(salary, commissionedRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}
