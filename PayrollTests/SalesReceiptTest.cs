using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Payroll;
using NUnit.Framework;

namespace PayrollTests
{
    public class SalesReceiptTest
    {
        [Test]
        public void TestSalesReceipt()
        {
            int empId = 6;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bill", "Home", 1000.0, 10.0);
            t.Execute();

            SalesReceiptTransaction tct = new SalesReceiptTransaction(new DateTime(2005, 7, 31), 100.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            CommissionedClassification hc = pc as CommissionedClassification;
            SalesReceipt tc = hc.GetSalesReceipt(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(100.0, tc.Amount);
        }
    }
}
