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

        public UnionAffiliation()
        {
            charges = new Hashtable();
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
