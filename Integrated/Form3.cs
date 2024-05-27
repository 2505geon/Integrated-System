using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Integrated
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Gian Lawrence\\source\\repos\\Integrated\\Integrated\\Database1.mdf\";Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    if (textPass.Text == textBox2.Text)
                    {
                        if (!IsUserRegistered(textUserN.Text))
                        {
                            RegisterUser(textUserN.Text, textBox1.Text, textPass.Text);
                            ClearForm();
                            MessageBox.Show("Registration successful.");
                            this.Close();
                            Form1 back = new Form1();
                            back.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("You are already registered.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password does not match.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private bool IsFormValid()
        {
            return !string.IsNullOrEmpty(textUserN.Text) &&
                   !string.IsNullOrEmpty(textBox1.Text) &&
                   !string.IsNullOrEmpty(textPass.Text) &&
                   !string.IsNullOrEmpty(textBox2.Text);
        }

        private bool IsUserRegistered(string name)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Gian Lawrence\\source\\repos\\Integrated\\Integrated\\Database1.mdf\";Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Register WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void RegisterUser(string name, string username, string password)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Gian Lawrence\\source\\repos\\Integrated\\Integrated\\Database1.mdf\";Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = NewInsertCommand(connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // Consider hashing the password before storing
                    command.ExecuteNonQuery();
                }
            }
        }

        private SqlCommand NewInsertCommand(SqlConnection connection)
        {
            string query = "INSERT INTO Register (Name, Username, Password) VALUES (@Name, @Username, @Password)";
            return new SqlCommand(query, connection);
        }

        private void ClearForm()
        {
            textUserN.Text = "";
            textBox1.Text = "";
            textPass.Text = "";
            textBox2.Text = "";
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
