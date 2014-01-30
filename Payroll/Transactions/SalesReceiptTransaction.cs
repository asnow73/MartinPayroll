using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class SalesReceiptTransaction :Transaction
    {
        private DateTime date;
        private double amount;
        private int empId;

        public SalesReceiptTransaction(DateTime dt, double amount, int id)
        {
            this.date = dt;
            this.amount = amount;
            this.empId = id;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
            {
                CommissionedClassification hc = e.Classification as CommissionedClassification;
                if (hc != null)
                    hc.AddSalesReceipt(new SalesReceipt(date, amount));
                else
                    throw new InvalidOperationException("Попытка регистрации справки о продажах для работника не на комиссионной оплате");
            }
            else
            {
                throw new InvalidOperationException("Работник не найден");
            }
        }
    }
}
