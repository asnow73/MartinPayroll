using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ChangeMailTransaction : ChangeMethodTransaction
    {
        private string address;

        public ChangeMailTransaction(int id, string address)
            : base(id)
        {
            this.address = address;
        }

        protected override PaymentMethod Method
        {
            get { return new MailMethod(address); }
        }
    }
}
