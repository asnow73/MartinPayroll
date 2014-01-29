using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class UnionAffiliation : Affiliation
    {
        private Hashtable charges;
        private double dues;
        private int memberId;

        public UnionAffiliation(int memberId, double dues)
        {
            charges = new Hashtable();
            this.dues = dues;
            this.memberId = memberId;
        }

        public double Dues
        {
            get { return this.dues; }
        }

        public int MemberId
        {
            get { return this.memberId; }
        }

        public ServiceCharge GetServiceCharge(DateTime time)
        {
            return (charges[time] as ServiceCharge);
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            charges[serviceCharge.Date] = serviceCharge;
        }

        private int NumberOfFridaysInPayPeriod(DateTime payPeriodStart, DateTime payPeriodEnd)
        {
            int fridays = 0;
            for (DateTime day = payPeriodStart; day <= payPeriodEnd; day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Friday)
                    fridays++;
            }
            return fridays;
        }

        public double CalculateDeductions(Paycheck paycheck)
        {
            double totalDues = 0;
            int fridays = NumberOfFridaysInPayPeriod(paycheck.PayPeriodStartDate, paycheck.PayPeriodEndDate);
            totalDues = dues * fridays;
            return totalDues;
        }

    }
}
