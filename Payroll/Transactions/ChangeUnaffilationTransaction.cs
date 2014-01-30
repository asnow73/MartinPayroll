using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ChangeUnaffilationTransaction : ChangeAffiliationTransaction
    {
        public ChangeUnaffilationTransaction(int id)
            : base(id)
        {
        }

        protected override Affiliation AffiliationType
        {
            get { return new NoAffiliation(); }
        }

        protected override void RecordMembership(Employee e)
        {
            Affiliation affiliation = e.Affiliation;
            if (affiliation is UnionAffiliation)
            {
                UnionAffiliation unionAffiliation = affiliation as UnionAffiliation;
                int memberId = unionAffiliation.MemberId;
                PayrollDatabase.RemoveUnionMember(memberId);
            }
        }
    }
}
