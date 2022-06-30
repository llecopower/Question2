using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Question2.BLL;

namespace Question2.Validation
{
    public static class Validator
    {
        public static bool IsValidID(string input)
        {

            int tempID;
            if ((input.Length != 5) || (Int32.TryParse(input, out tempID)))
            {
                MessageBox.Show("Invalid CustomerID, it must be a 5 digit number");
                return false;
            }
            return true;

        }
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 5) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid CustomerID, it must be a 5 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;

        }
        public static bool IsValidName(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i) || (char.IsWhiteSpace(text.Text, i)))
                {
                    MessageBox.Show("Invalid Name,Please enter another name.", "INVALID NAME");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            }
            return true;

        }
        public static bool IsUniqueID(List<Customer> listC, int id)
        {
            foreach (Customer c in listC)
            {
                if (c.CustomerId == id)
                {
                    MessageBox.Show("Duplicate ID, please enter a unique one.");
                    return false;
                }
            }
            return true;
        }
    }
}