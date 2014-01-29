using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Payroll;

namespace PayrollTests
{
    public class PaydayTest
    {
        [Test]
        public void PaySingleSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.0);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 30);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId);
            Assert.IsNotNull(pc);
            Assert.AreEqual(payDate, pc.PayDate);
            Assert.AreEqual(1000.0, pc.GrossPay, .001);
            //Assert.AreEqual("Hold", pc.getField("Disposition"));
            Assert.AreEqual(0.0, pc.Deductions, .001);
            Assert.AreEqual(1000.0, pc.NetPay, .001);
        }

        [Test]
        public void PaySingleSalariedEmployeeOnWrongDate()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.0);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 29);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId);
            Assert.IsNull(pc);
        }

        private void ValidatePaycheck(PaydayTransaction pt, int empId, DateTime payDate, double pay)
        {
            Paycheck pc = pt.GetPaycheck(empId);
            Assert.IsNotNull(pc);
            Assert.AreEqual(payDate, pc.PayDate);
            Assert.AreEqual(pay, pc.GrossPay, .001);
            //Assert.AreEqual("Hold", pc.GetField("Disposition"));
            Assert.AreEqual(0.0, pc.Deductions, .001);
            Assert.AreEqual(pay, pc.NetPay, .001);
        }

        [Test]
        public void PayingSingleHourlyEmployeeNoTimeCards()
        {
            int empId = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "bob", "home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, 0.0);
        }

        [Test]
        public void PaySingleHourlyEmployeeOneTimeCard()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "bob", "home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); //пятница
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, 30.5);
        }

        [Test]
        public void PaySingleHourlyEmployeeOvertimeOneTimeCard()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "bob", "home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); //пятница
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, (8 + 1.5)*15.25);
        }

        [Test]
        public void PaySingleHourlyEmployeeOnWrongDate()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "bob", "home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 8); //четверг
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId);
            Assert.IsNull(pc);
        }

        [Test]
        public void PaySingleHourlyEmployeeTwoTimeCards()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "bob", "home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); //пятница
            TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
            tc.Execute();
            TimeCardTransaction tc2 = new TimeCardTransaction(payDate.AddDays(-1), 5.0, empId);
            tc2.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, 7 * 15.25);
        }

        [Test]
        public void PaySingleHourlyEmployeeWithTimeCardsSpanningTwoPayPeriods()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "bob", "home", 15.25);
            t.Execute();

            DateTime payDate = new DateTime(2001, 11, 9); //пятница
            DateTime dateInPreviousPayPeriod = new DateTime(2001, 11, 2);

            TimeCardTransaction tc = new TimeCardTransaction(payDate, 2.0, empId);
            tc.Execute();
            TimeCardTransaction tc2 = new TimeCardTransaction(dateInPreviousPayPeriod, 5.0, empId);
            tc2.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, 2 * 15.25);
        }

        [Test]
        public void PayCommisionedEmployee()
        {
            int empId = 2;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "bob", "home", 1000.0, 10.0);
            t.Execute();

            DateTime payDate = new DateTime(2014, 01, 10); //вторая пятница            

            SalesReceiptTransaction tc = new SalesReceiptTransaction(payDate.AddDays(-1), 100.0, empId);
            tc.Execute();
            SalesReceiptTransaction tc2 = new SalesReceiptTransaction(payDate.AddDays(-2), 100.0, empId);
            tc2.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, 1000.0 + 2 * ((100.0 / 100) * 10.0));
        }

        [Test]
        public void PayCommisionedEmployeeOnWrongDate()
        {
            int empId = 2;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "bob", "home", 1000.0, 10.0);
            t.Execute();

            DateTime payDate = new DateTime(2014, 01, 9); //четверг

            SalesReceiptTransaction tc = new SalesReceiptTransaction(payDate.AddDays(-1), 100.0, empId);
            tc.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId);
            Assert.IsNull(pc);
        }

        [Test]
        public void PayCommisionedEmployeePayPeriodCheck()
        {
            int empId = 2;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "bob", "home", 1000.0, 10.0);
            t.Execute();

            DateTime payDate = new DateTime(2014, 01, 10); //вторая пятница

            SalesReceiptTransaction tc = new SalesReceiptTransaction(payDate.AddDays(-1), 100.0, empId);
            tc.Execute();
            SalesReceiptTransaction tc2 = new SalesReceiptTransaction(payDate.AddDays(-31), 100.0, empId);
            tc2.Execute();

            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            ValidatePaycheck(pt, empId, payDate, 1000.0 + ((100.0 / 100) * 10.0));
        }

        [Test]
        public void SalariedUnionMember()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bill", "Home", 1000.0);
            t.Execute();

            int memberId = 7739;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memberId, 9.42);
            cmt.Execute();

            DateTime payDate = new DateTime(2001, 11, 30);
            PaydayTransaction pt = new PaydayTransaction(payDate);
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId);
            Assert.IsNotNull(pc);
            Assert.AreEqual(payDate, pc.PayDate);
            Assert.AreEqual(1000.0, pc.GrossPay, .001);

            //Assert.AreEqual("Hold", pc.GetField("Disposition"));

            Assert.AreEqual(47.1, pc.Deductions, .001);
            Assert.AreEqual(1000.0 - 47.1, pc.NetPay, .001);
        }
    }
}
