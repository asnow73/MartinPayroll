using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class DeleteEmployeeTransaction : Transaction
    {
        private int empid;

        public DeleteEmployeeTransaction(int id)
        {
            this.empid = id;
        }

        public void Execute()
        {
            PayrollDatabase.DeleteEmployee(empid);
        }
    }
}
