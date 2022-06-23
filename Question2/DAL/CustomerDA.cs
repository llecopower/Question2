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



       
    }
}
