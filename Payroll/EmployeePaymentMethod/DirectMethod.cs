using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class DirectMethod : PaymentMethod
    {
        private string bank;
        private int account;

        public DirectMethod(string bank, int account)
        {
            this.bank = bank;
            this.account = account;
        }

        public string Bank
        {
            get { return this.bank; }
            set { this.bank = value; }
        }

        public int Account
        {
            get { return this.account; }
            set { this.account = value; }
        }
    }
}
