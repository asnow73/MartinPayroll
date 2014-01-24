using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class Employee
    {
        private int id;
        private string name;
        private string address;
        private PaymentClassification classification;
        private PaymentSchedule schedule;
        private PaymentMethod method;
        private Affiliation affiliation;

        public Employee(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.affiliation = null;
        }

        public Affiliation Affiliation
        {
            get { return this.affiliation; }
            set { this.affiliation = value; }
        }

        public PaymentClassification Classification
        {
            get { return classification; }
            set { this.classification = value;  }
        }

        public PaymentSchedule Schedule
        {
            get { return schedule; }
            set { this.schedule = value; }
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Address
        {
            get { return address; }
            set { this.address = value; }
        }

        public PaymentMethod Method
        {
            get { return method; }
            set { this.method = value; }
        }
    }
}
