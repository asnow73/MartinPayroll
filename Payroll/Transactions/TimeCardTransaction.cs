using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class TimeCardTransaction : Transaction
    {
        private DateTime date;
        private double hours;
        private int empId;

        public TimeCardTransaction(DateTime dt, double hours, int id)
        {
            this.date = dt;
            this.hours = hours;
            this.empId = id;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
            {
                HourlyClassification hc = e.Classification as HourlyClassification;
                if (hc != null)
                    hc.AddTimeCard(new TimeCard(date, hours));
                else
                    throw new InvalidOperationException("Попытка добавить карточку учёта для работника не на почасовой оплате");
            }
            else
            {
                throw new InvalidOperationException("Работник не найден");
            }
        }
    }
}
