using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace inventory
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            txtConfirmPassword.PasswordChar = '•';
            txtNewPassword.PasswordChar = '•';
            txtuname.Text = Class1.uname;
            txtOldPassword.PasswordChar = '•';
        }
        public string connString = "datasource=localhost;username=root;password=;database=pauls";
        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }
        public void update(string newpass,String Username)
        {
            MySqlConnection conn1 = new MySqlConnection(connString);
            try
            {

                conn1.Open();
                string query = "UPDATE  tbll_account SET Password = '" + newpass + "' WHERE Username = '" + Username + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    MessageBox.Show("The Password Changed");
                    


                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ChangePass()
        {
            MySqlConnection conn1 = new MySqlConnection(connString);
            try
            {
                conn1.Open();
                string sqlquery = "SELECT * FROM tbll_account WHERE Username = @fName";

                MySqlCommand command = new MySqlCommand(sqlquery, conn1);
                MySqlDataReader sReader;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@fName", Class1.uname);
                sReader = command.ExecuteReader();

                while (sReader.Read())
                {
                    String oldPassword = sReader["Password"].ToString(); //SqlDataReader

                    if(oldPassword == txtOldPassword.Text)
                    {
                        String newcounts = txtNewPassword.Text;
                        String confirmcounts = txtConfirmPassword.Text;

                        if (newcounts.Length < 7 )
                        {
                            Change.Enabled = false;
                            txtError.Text = "You need the password more than 8 letters";
                            
                        }else if(newcounts != confirmcounts)
                        {
                            Change.Enabled = false;
                            txtError.Text = "The new Password and Confirm not same";
                        }
                        else if (newcounts == confirmcounts)
                        {
                            Change.Enabled = true;
                            txtError.Text = "";
                        }
                        else
                        {
                            Change.Enabled = false;
                            txtError.Text = "";
                        }
                    }
                    else
                    {
                        txtError.Text = "Your Old Password is incorrect";
                    }
                                                                           

                    //["age"] another column you want to retrieve
                }
                conn1.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {
            Form HOME = new ACCOUNT();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {
            Form HOME = new incident();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            Form HOME = new MainDashboard();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {
            Form HOME = new Form1();
            HOME.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            update(txtConfirmPassword.Text,Class1.uname);
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            
            ChangePass();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ChangePass();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ChangePass();
        }
    }
}
