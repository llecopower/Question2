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
        private string firstName;
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        //Default constructor

        public Person()
        {
            firstName = "Mary";
            lastName = "Brown";
        }

        // Paramerterized constructor (also called Overloaded constructor
        public Person(string fName, string lName)
        {
            lastName = lName;
            firstName = fName;

        }
        //public Person(string firstName, string lastName)
        //{
        //    this.lastName = lastName;
        //    this.firstName = firstName;

        //}

        //Method
        public virtual string DisplayInfo()
        {
            return (firstName + "," + lastName);
        }

    }
}
