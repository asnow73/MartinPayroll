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

        private double CalculatePayForTimeCard(TimeCard card)
        {
            double overtimeHours = Math.Max(0.0, card.Hours - 8);
            double normalHours = card.Hours - overtimeHours;
            return hourlyRate * normalHours + hourlyRate * 1.5 * overtimeHours;
        }

        public override double CalculatePay(Paycheck paycheck)
        {
            double totalPay = 0.0;
            foreach (TimeCard timeCard in timeCards.Values)
            {
                if (DateUtil.IsInPayPeriod(timeCard.Date, paycheck.PayPeriodStartDate, paycheck.PayPeriodEndDate))
                    totalPay += CalculatePayForTimeCard(timeCard);
            }
            return totalPay;
        }
    }
}
