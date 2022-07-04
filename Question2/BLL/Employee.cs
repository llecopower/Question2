using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2.BLL
{
   public class Employee : Person
    {
        //INHERITANCE FROM PERSON
        private int employeeId;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        //Default constructor

        public Employee() : base()
        {
            employeeId = 12345;
        }


        //Parameterized contructor

        public Employee(int empId, string fname, string lname) : base(fname, lname)
        {
            employeeId = empId;

        }

        public override string DisplayInfo()
        {
            string info = employeeId + "," + base.DisplayInfo();
            return info;
        }



    }
}
