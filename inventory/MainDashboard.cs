using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace inventory
{
    public partial class MainDashboard : Form
    {
        public string conn = "datasource=localhost;username=root;password=;database=pauls";
        public MainDashboard()
        {
            InitializeComponent();
            getdata();
        }
        public void getdata()
        {
            txtuname.Text = Class1.uname;
            MySqlConnection conn1 = new MySqlConnection(conn);
            try
            {
                conn1.Open();
                int pendding = 0;
                string query1 = "select count(status)  from tbl_tasks where status='PENDING'";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn1);
                pendding = Convert.ToInt32(cmd1.ExecuteScalar());
                pending.Text = pendding.ToString();

                // Open a new connection for the second query

                int ongoings = 0;
                string query3 = "select count(status)  from tbl_tasks where status='ONGOING'";
                MySqlCommand cmd3 = new MySqlCommand(query3, conn1);
                ongoings = Convert.ToInt32(cmd3.ExecuteScalar());
                ongoing.Text = ongoings.ToString();

                int completedd = 0;
                string query2 = "select count(status)  from tbl_tasks where status = 'COMPLETE'";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn1);
                completedd = Convert.ToInt32(cmd2.ExecuteScalar());
                completed.Text = completedd.ToString();
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {
            Form HOME = new ACCOUNT();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel17_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void pending_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            Form HOME = new Form1();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click_1(object sender, EventArgs e)
        {
            Form HOME = new incident();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click_1(object sender, EventArgs e)
        {
            Form HOME = new incident();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel11_Click_1(object sender, EventArgs e)
        {
            Form HOME = new Form1();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel19_Click_1(object sender, EventArgs e)
        {
            Form HOME = new ACCOUNT();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel7_Click_1(object sender, EventArgs e)
        {
            Form HOME = new Setting();
            HOME.Show();
            this.Hide();
        }
    }
}
