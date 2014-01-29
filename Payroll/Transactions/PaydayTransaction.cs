using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class PaydayTransaction : Transaction
    {
        private DateTime payDate;
        private Hashtable paychecks;

        public PaydayTransaction(DateTime payDate)
        {
            this.payDate = payDate;
            this.paychecks = new Hashtable();
        }

        public void Execute()
        {
            ICollection empIds = PayrollDatabase.GetAllEmployeeIds();
            foreach (int empId in empIds)
            {
                Employee employee = PayrollDatabase.GetEmployee(empId);
                if (employee.IsPayDate(payDate))
                {
                    DateTime startDate = employee.GetPayPeriodStartDate(payDate);
                    Paycheck pc = new Paycheck(startDate, payDate);
                    paychecks[empId] = pc;
                    employee.PayDay(pc);
                }
            }
        }

        public Paycheck GetPaycheck(int empId)
        {
            return (paychecks[empId] as Paycheck);
        }

    }
}
