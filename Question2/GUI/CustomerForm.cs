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
            buttonListCustomers.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void ClearAll() {

           textBoxCustomerId.Clear();
           textBoxFirstName.Clear();
           textBoxLastName.Clear();
           maskedTextBoxPhoneNumber.Clear();
           textBoxCustomerId.Focus();
        
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
           // buttonListCustomers.Enabled = false;
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {

            //QA - Add the view at the list 

            Customer aCustomer = new Customer();
            if ((Validator.IsValidID(textBoxCustomerId)) && (Validator.IsValidName(textBoxFirstName)) && (Validator.IsValidName(textBoxLastName)) && Validator.IsUniqueID(listC, Convert.ToInt32(textBoxCustomerId.Text)))
            {
                aCustomer.CustomerId = Convert.ToInt32(textBoxCustomerId.Text);
                aCustomer.FirstName = textBoxFirstName.Text;
                aCustomer.LastName = textBoxLastName.Text;
                aCustomer.PhoneNumber = maskedTextBoxPhoneNumber.Text;
                //Add to the list
                listC.Add(aCustomer);
                //  MessageBox.Show("Customer Info has been added to the list.","Confirmation");
                buttonListCustomers.Enabled = true;
                ClearAll();

            }


        }    
        

            
        
        
        private void buttonListCustomers_Click(object sender, EventArgs e)
        {
            listViewCustomer.Items.Clear();
            CustomerDA.ListCustomers(listViewCustomer);
        }

     

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<Customer> listC = CustomerDA.ListCustomers();

            Customer aCustomer = new Customer();

            aCustomer.CustomerId = Convert.ToInt32(textBoxCustomerId.Text);
            aCustomer.FirstName = textBoxFirstName.Text;
            aCustomer.LastName = textBoxLastName.Text;
            aCustomer.PhoneNumber = maskedTextBoxPhoneNumber.Text;

            CustomerDA.Save(aCustomer);

            ClearAll();    
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int choice = comboBoxChoice.SelectedIndex;

            //ALEX HOMEWORK SEARCH FOR CASES BEYOND -1, if exists

            //Students homework: search by First and Last Name as well


            switch (choice)
            {
                case -1: // IF the user NOT select any search option

                    MessageBox.Show("Please, select at least one Search Option");
                    break;

                case 0:
                    Customer cust = CustomerDA.Search(Convert.ToInt32(textBoxInput.Text));

                    if (cust != null)
                    {
                        textBoxCustomerId.Text = (cust.CustomerId).ToString();
                        textBoxFirstName.Text = cust.FirstName;
                        textBoxLastName.Text = cust.LastName;
                        maskedTextBoxPhoneNumber.Text = cust.PhoneNumber;
                    }
                    else
                    {

                        MessageBox.Show("Customer not found!");
                    }
                    break;




                default:   // IF the user NOT select an option on the  search combo box
                    break;
            }





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
           CustomerDA.Delete(Convert.ToInt32(textBoxCustomerId.Text));
            MessageBox.Show("Customer record has been deleted successfully", "Delete");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.CustomerId = Convert.ToInt32(textBoxInput.Text);
            cust.FirstName = textBoxFirstName.Text;
            cust.LastName =  textBoxLastName.Text;
            cust.PhoneNumber = maskedTextBoxPhoneNumber.Text;

            DialogResult ans = MessageBox.Show("Do you really want to update this customer?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ans == DialogResult.Yes)
            {
                CustomerDA.Update(cust);

            }
            

        }

        private void comboBoxExample_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
