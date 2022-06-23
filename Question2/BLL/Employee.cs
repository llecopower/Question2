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
        public int EmployeeId { get; set; }

        //Default Constructor
        public Employee() : base()
        {
            EmployeeId = 12345;
        } 
        
        //parametrized Constructor

        public Employee(int empId, string fname, string lname) : base(fname,lname)
        {
            EmployeeId = empId;
        }

        public override string DisplayInfo()
        {
            string info = EmployeeId + ", " + base.DisplayInfo();

            return info;
        }







    }
}
