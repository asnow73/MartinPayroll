﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Payroll
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();
        private static Hashtable unionMembers = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static void DeleteEmployee(int id)
        {
            employees.Remove(id);
        }

        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }

        public static Employee GetUnionMember(int memberId)
        {
            return (unionMembers[memberId] as Employee);
        }

        public static void AddUnionMember(int memberId, Employee e)
        {
            unionMembers[memberId] = e;
        }

        public static void RemoveUnionMember(int memberId)
        {
            unionMembers.Remove(memberId);
        }

        public static ICollection GetAllEmployeeIds()
        {
            return employees.Keys;
        }
    }
}
