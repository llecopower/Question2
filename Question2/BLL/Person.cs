using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2.BLL
{
    //base class
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

               
        //Default Constructor
        public Person()
        {
            FirstName = "Bruno";
            LastName = "Henkels";
        }

        //parameterized Constructor (also called overloaded constructor)
        public Person(string fName, string lName)
            {
                FirstName = fName;
                LastName = lName;
            }

        //Method
        public virtual string DisplayInfo()
        { 
            return LastName + ", " + FirstName;
        }


    }
}
