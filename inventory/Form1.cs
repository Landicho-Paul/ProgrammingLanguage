using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inventory
{


    public partial class Form1 : Form
    {
        public string conn = "datasource=localhost;username=root;password=;database=pauls";

        public void login(string username, string pass)
        {
            MySqlConnection conn1 = new MySqlConnection(conn);
            try
            {
                conn1.Open();
                string query = "SELECT * FROM tbll_account WHERE username = '" + username + "' AND password ='" + pass + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    Class1.uname = uname.Text;
                    this.Hide();
                    Form HOME = new MainDashboard();
                    HOME.Show();
                    

                }
                else
                {
                    MessageBox.Show("Wrong Credentials, Please Try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public Form1()
        {
            InitializeComponent();
            password.PasswordChar = '•';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            login(uname.Text, password.Text);
        }
    }
}
