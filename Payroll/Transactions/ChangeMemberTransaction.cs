using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private int memberId;
        private double dues;

        public ChangeMemberTransaction(int id, int member_id, double dues)
            : base(id)
        {
            this.memberId = member_id;
            this.dues = dues;
        }

        protected override Affiliation AffiliationType
        {
            get { return new UnionAffiliation(memberId, dues); }
        }

        protected override void RecordMembership(Employee e)
        {
            PayrollDatabase.AddUnionMember(memberId, e);
        }
    }
}
