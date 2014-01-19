using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private double hourlyRate;

        public AddHourlyEmployee(int empid, string name, string address, double hourlyRate)
            : base(empid, name, address)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClassification(hourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }

        public double HourlyRate
        {
            get { return hourlyRate; }
        }
    }
}
