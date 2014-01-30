using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffiliationTransaction(int id)
            : base(id)
        {
        }

        protected override void Change(Employee e)
        {
            RecordMembership(e);
            e.Affiliation = AffiliationType;
        }

        protected abstract Affiliation AffiliationType { get; }
        protected abstract void RecordMembership(Employee e);
    }
}
