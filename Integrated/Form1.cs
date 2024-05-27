using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Integrated
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Gian Lawrence\\source\\repos\\Integrated\\Integrated\\Database1.mdf\";Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textUserN.Text) && !string.IsNullOrEmpty(textPass.Text))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Register WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", textUserN.Text);
                        command.Parameters.AddWithValue("@Password", textPass.Text);

                        connection.Open();
                        int v = (int)command.ExecuteScalar();
                        connection.Close();

                        if (v == 1)
                        {
                            new Form2().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("The Username or Password You Entered Is Incorrect.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter both Username and Password.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }
    }
}
