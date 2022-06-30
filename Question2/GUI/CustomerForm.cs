using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Question2.BLL;
using Question2.Validation;
using System.IO;
using Question2.DAL;

namespace Question2.GUI
{
    public partial class CustomerForm : Form
    {
        List<Customer> listC = new List<Customer>();



        public CustomerForm()
        {
            InitializeComponent();
            buttonListCustomers.Enabled = false;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult asnwer = MessageBox.Show("Are you sure to exit the Application?", "Confirmation",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (asnwer == DialogResult.Yes)
            {
                Application.Exit();

            }

            
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
           // buttonListCustomers.Enabled = false;
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();
            if ((Validator.IsValidID(textBoxCustomerId)) && (Validator.IsValidName(textBoxFirstName)) && 
                (Validator.IsValidName(textBoxLastName)) && Validator.IsUniqueID(listC, Convert.ToInt32(textBoxCustomerId.Text)))
            {
               aCustomer.CustomerId = Convert.ToInt32(textBoxCustomerId.Text);
               aCustomer.FirstName = textBoxFirstName.Text;
               aCustomer.LastName = textBoxLastName.Text;
               aCustomer.PhoneNumber = maskedTextBoxPhoneNumber.Text;

                //add to the list
                listC.Add(aCustomer);

                MessageBox.Show("Custormer Info Has been added to the list", "Confirmation");
                buttonListCustomers.Enabled = true;
                //ClearAll();


            }
                        
            
        }
        
        private void buttonListCustomers_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearAll()
        {
            
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            

            

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
                       

        }

        private void comboBoxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
           int choice = comboBoxChoice.SelectedIndex;

            switch (choice)
            { 
                case 0:
                    labelInfo.Text = "Please enter the Customer ID";
                    textBoxInput.Focus();
                    break;

                case 1:
                    labelInfo.Text = "Please enter the First Name";
                    textBoxInput.Focus();
                    break;

                case 2:
                    labelInfo.Text = "Please enter the Last Name";
                    textBoxInput.Focus();
                    break;

                    default:
                    break;



            }


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
                       
        }

        private void comboBoxExample_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
