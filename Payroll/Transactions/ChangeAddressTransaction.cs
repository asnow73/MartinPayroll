using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string address;

        public ChangeAddressTransaction(int id, string address)
            : base(id)
        {
            this.address = address;
        }

        protected override void Change(Employee e)
        {
            e.Address = address;
        }
    }
}
