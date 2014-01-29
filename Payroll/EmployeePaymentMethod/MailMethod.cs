using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class MailMethod : PaymentMethod
    {
        private string address;

        public MailMethod(string address)
        {
            this.address = address;
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public void Pay(Paycheck paycheck)
        {
        }
    }
}
