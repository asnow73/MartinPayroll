using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Payroll;

namespace PayrollTests
{
    public class DelEmployeeTest
    {
        [Test]
        public void TestDeleteEmployee()
        {
            int empId = 4;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 2500, 3.2);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();

            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }
    }
}
