using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Payroll;
using NUnit.Framework;

namespace PayrollTests
{
    class ServiceChargeTest
    {
        [Test]
        public void TestAddServiceCharge()
        {
            int empId = 7;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 15.25);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            UnionAffiliation af = new UnionAffiliation();
            e.Affiliation = af;

            int memberId = 86; // Maxwell Smart
            PayrollDatabase.AddUnionMember(memberId, e);

            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2005, 8, 8), 12.95);
            sct.Execute();

            ServiceCharge sc = af.GetServiceCharge(new DateTime(2005, 8, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }
    }
}
