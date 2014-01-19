using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Payroll;

namespace PayrollTests
{
    public class AddEmployeeTest
    {
        [Test]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddHourlyEmployee()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Stan", "Home", 100.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Stan", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification sc = pc as HourlyClassification;
            Assert.AreEqual(100.00, sc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddCommissionedEmployee()
        {
            int empId = 3;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Rosa", "Home", 1100.00, 5.5);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Rosa", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(1100.00, sc.Salary, .001);
            Assert.AreEqual(5.5, sc.CommissionedRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}
