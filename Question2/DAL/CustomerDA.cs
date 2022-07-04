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
    public static class CustomerDA
    {
        private static string filePath = Application.StartupPath + @"\Customers.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Customer cust)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(cust.CustomerId + "," + cust.FirstName + "," + cust.LastName + "," + cust.PhoneNumber);
            sWriter.Close();
            MessageBox.Show("Customer Data has been saved.");

        }

        public static void ListCustomers(ListView listViewCustomer)
        {
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath);
            listViewCustomer.Items.Clear();
            // Step 2: Read the file until teh end of the file
            //         - Read line by line
            //         - Split the line into an array of string based on seperator
            //         - Add data to the listView control

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                listViewCustomer.Items.Add(item);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }

        public static List<Customer> ListCustomers()
        {
            List<Customer> listC = new List<Customer>();
            //step 1: Create an object of type StreamReader
            StreamReader sReader = new StreamReader(filePath);
            // Step 2: Read the file until teh end of the file
            //         - Read line by line
            //         - Split the line into an array of string based on seperator
            //         - Create an object of type Customer
            //         -Store data in the object Customer
            //         -Add the object to the listC
            //         -Close the file : VERY IMPORTANT

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                Customer cust = new Customer();
                cust.CustomerId = Convert.ToInt32(fields[0]);
                cust.FirstName = fields[1];
                cust.LastName = fields[2];
                cust.PhoneNumber = fields[3];
                listC.Add(cust);
                line = sReader.ReadLine();
            }
            sReader.Close(); //Close the file
            return listC;
        }

        public static Customer Search(int custId)
        {
            Customer cust = new Customer();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (custId == Convert.ToInt32(fields[0]))
                {
                    cust.CustomerId = Convert.ToInt32(fields[0]);
                    cust.FirstName = fields[1];
                    cust.LastName = fields[2];
                    cust.PhoneNumber = fields[3];
                    sReader.Close();
                    return cust;
                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();//Fixing the Problem by closing the file
            return null;
        }
        public static void Delete(int custId)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((custId) != (Convert.ToInt32(fields[0])))
                {

                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);


                }
                line = sReader.ReadLine(); // Attention : read the next line 
            }
            sReader.Close();
            sWriter.Close();
            //Delete the old file : Customers.dat
            File.Delete(filePath); // Problem here : solved, see the Search method
            File.Move(fileTemp, filePath);

        }

        public static void Update(Customer cust)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Convert.ToInt32(fields[0]) != (cust.CustomerId)))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);
                }

                line = sReader.ReadLine();// Attention : read the next line        
            }
            sWriter.WriteLine(cust.CustomerId + "," + cust.FirstName + "," + cust.LastName + "," + cust.PhoneNumber);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);


        }

    }
}

