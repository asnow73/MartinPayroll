using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class HourlyClassification : PaymentClassification
    {
        private Hashtable timeCards;
        private double hourlyRate;

        public HourlyClassification(double hourlyRate)
        {
            this.hourlyRate = hourlyRate;
            this.timeCards = new Hashtable();
        }

        public double HourlyRate
        {
            get { return hourlyRate; }
        }

        public void AddTimeCard(TimeCard tc)
        {
            timeCards[tc.Date] = tc;
        }

        public TimeCard GetTimeCard(DateTime date)
        {
            return (timeCards[date] as TimeCard);
        }
    }
}
