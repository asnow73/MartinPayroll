using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Payroll;
using NUnit.Framework;

namespace PayrollTests
{
    public class UpdateEmployeeTest
    {
        [Test]
        public void TestChangeNameTransaction()
        {
            int empId = 8;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        [Test]
        public void TestChangeAddressTransaction()
        {
            int empId = 8;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            ChangeAddressTransaction cnt = new ChangeAddressTransaction(empId, "NewHome");
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("NewHome", e.Address);
        }

        [Test]
        public void TestChangeHourlyTransaction()
        {
            int empId = 9;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 2500, 3.2);
            t.Execute();

            ChangeHourlyTransaction cnt = new ChangeHourlyTransaction(empId, 27.52);
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [Test]
        public void TestChangeSalariedTransaction()
        {
            int empId = 10;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 2500, 3.2);
            t.Execute();

            ChangeSalariedTransaction cnt = new ChangeSalariedTransaction(empId, 1000.0);
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification hc = pc as SalariedClassification;
            Assert.AreEqual(1000.0, hc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
        }

        [Test]
        public void TestChangeCommissionedTransaction()
        {
            int empId = 11;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 3.2);
            t.Execute();

            ChangeCommissionedTransaction cnt = new ChangeCommissionedTransaction(empId, 1000.0, 12.12);
            cnt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is CommissionedClassification);

            CommissionedClassification hc = pc as CommissionedClassification;
            Assert.AreEqual(1000.0, hc.Salary, .001);
            Assert.AreEqual(12.12, hc.CommissionedRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }

        [Test]
        public void TestChangeDirectTransaction()
        {
            int empId = 10;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 3.2);
            t.Execute();

            ChangeDirectTransaction dt = new ChangeDirectTransaction(empId, "bank", 123456);
            dt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentMethod method = e.Method;
            Assert.IsTrue(method is DirectMethod);

            DirectMethod dm = e.Method as DirectMethod;
            Assert.AreEqual(123456, dm.Account);
            Assert.AreEqual("bank", dm.Bank);
        }

        [Test]
        public void TestChangeHoldTransaction()
        {
            int empId = 10;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 3.2);
            t.Execute();

            ChangeHoldTransaction dt = new ChangeHoldTransaction(empId);
            dt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentMethod method = e.Method;
            Assert.IsTrue(method is HoldMethod);
        }

        [Test]
        public void TestChangeMailTransaction()
        {
            int empId = 10;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 3.2);
            t.Execute();

            ChangeMailTransaction dt = new ChangeMailTransaction(empId, "Home");
            dt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            PaymentMethod method = e.Method;
            Assert.IsTrue(method is MailMethod);

            MailMethod mm = e.Method as MailMethod;
            Assert.AreEqual("Home", mm.Address);
        }

        [Test]
        public void TestChangeMemberTransaction()
        {
            int empId = 10;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 15.25);
            t.Execute();

            int memberId = 7743;
            ChangeMemberTransaction dt = new ChangeMemberTransaction(empId, memberId, 99.42);
            dt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Affiliation affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffiliation);

            UnionAffiliation uf = affiliation as UnionAffiliation;
            Assert.AreEqual(99.42, uf.Dues, .001);
            Employee member = PayrollDatabase.GetUnionMember(memberId);
            Assert.AreEqual(e, member);
        }
    }
}
