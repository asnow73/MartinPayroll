using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ChangeDirectTransaction : ChangeMethodTransaction
    {
        private string bank;
        private int account;

        public ChangeDirectTransaction(int id, string bank, int account)
            : base(id)
        {
            this.bank = bank;
            this.account = account;
        }

        protected override PaymentMethod Method
        {
            get { return new DirectMethod(bank, account); }
        }
    }
}
