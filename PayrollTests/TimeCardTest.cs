using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Payroll;

namespace PayrollTests
{
    public class TimeCardTest
    {
        [Test]
        public void TestTimeCardTransaction()
        {
            int empId = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2005, 7, 31), 8.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            TimeCard tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }
    }
}
