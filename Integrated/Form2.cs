using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Integrated
{
    public partial class Form2 : Form
    {

        private Form crrntchldfrm;
        public Form2()
        {
            InitializeComponent();
        }
        private void Openchildform(Form childform)
        {

            if (crrntchldfrm != null)
            {
                crrntchldfrm.Close();
            }
            
            {
                crrntchldfrm = childform;
                childform.TopLevel = false;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.Dock = DockStyle.Fill;
                panel4.Controls.Add(childform);
                panel4.Tag = childform;
                childform.BringToFront();
                childform.Show();


            }



        }
        private void Button1_Click(object sender, EventArgs e) {
           
            Openchildform(new Formdashboard());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Openchildform(new FormSales());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Openchildform(new FormTransactions());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Openchildform(new FormInventory());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Openchildform(new Payroll());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out of this account?",
                                        "Confirm Logout",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            // Check the result of the dialog
            if (result == DialogResult.Yes)
            {
               
                this.Close(); 
            }
            else
            {
                // The user clicked No, do nothing
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Exit?",
                                        "Confirm Exit",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            // Check the result of the dialog
            if (result == DialogResult.Yes)
            {

                this.Close();
            }
            else
            {
                // The user clicked No, do nothing
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }
    }
}
