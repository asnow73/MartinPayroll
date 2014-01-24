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
    }
}
