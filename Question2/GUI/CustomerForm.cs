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
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            
                        
            
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
