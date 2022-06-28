using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question2.BLL;
using System.Windows.Forms;
using System.IO;

namespace Question2.DAL
{

    //STATIC WILL AVOID TO CREATE INS
   public static  class CustomerDA
    {

        private static string filePath = Application.StartupPath + @"\Customers.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        //
        public static void Save(Customer cust)
        { 
            StreamWriter sWriter = new StreamWriter(filePath,true);
            sWriter.WriteLine(cust.CustomerId + "," + cust.FirstName + "," + cust.LastName + ", " + cust.PhoneNumber);
            sWriter.Close();
            MessageBox.Show("Custormer Data has been saved!");
        }
        public static void ListCustomers(ListView listViewCustomer)
        { 
            StreamReader sReader = new StreamReader(filePath);
            listViewCustomer.Items.Clear();
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                listViewCustomer.Items.Add(item);
                line = sReader.ReadLine();

            }
            sReader.Close();
        }

        public static List<Customer> ListCustomers()
        {        
            List<Customer> listC = new List<Customer>();

            //Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath);  
           
            // - Reader line by line
            string line = sReader.ReadLine();

            while (line != null)
            {   // - Split the line into array of string based on separator
                string[] fields = line.Split(',');

                // - Create an Object of type Customer
                Customer cust = new Customer();

                // - Store data in the Object Customer
                cust.CustomerId = Convert.ToInt32(fields[0]);
                cust.FirstName = fields[1];
                cust.LastName = fields[2];
                cust.PhoneNumber = fields[3];

                // - Add the Object to the listC
                listC.Add(cust);

               // -Read the file UNTIL the end of the file
                line = sReader.ReadLine();

            }
            //- Close the file !!! VERY IMPORTANT
            sReader.Close();
            return listC;

        }



       
    }
}
