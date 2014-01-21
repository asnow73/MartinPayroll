using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ServiceChargeTransaction : Transaction
    {
        private int memberId;
        private DateTime time;
        private double charge;

        public ServiceChargeTransaction(int id, DateTime time, double charge)
        {
            this.charge = charge;
            this.time = time;
            this.memberId = id;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetUnionMember(memberId);
            if (e != null)
            {
                UnionAffiliation ua = null;
                if (e.Affiliation is UnionAffiliation)
                    ua = e.Affiliation as UnionAffiliation;

                if (ua != null)
                    ua.AddServiceCharge(new ServiceCharge(time, charge));
                else
                    throw new InvalidOperationException("Попытка добавить плату за услуги для члена профсоюза с незарегистрированным членством");
            }
            else
            {
                throw new InvalidOperationException("Член профсоюза не найден");
            }
        }
    }
}
