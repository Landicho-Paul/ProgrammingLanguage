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

namespace inventory
{
    public partial class ACCOUNT : Form
    {
        public ACCOUNT()
        {
            InitializeComponent();
            loadData();
        }
        public string connString = "datasource=localhost;username=root;password=;database=pauls";
        public void loadData()
        {
            txtuname.Text = Class1.uname;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                String query = "SELECT Firstname,Lastname,Username,Email from tbll_account";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);
                toolsdt.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        public void Add(String Firstname, String Middlename, String Lastname, String Username, String Password, String Email)
        {
            MySqlConnection conn1 = new MySqlConnection(connString);
            try
            {

                conn1.Open();
                string query = "INSERT INTO tbll_account (Firstname, Middlename, Lastname, Username, Password,Email) VALUES ('" + Firstname + "','" + Middlename + "','" + Lastname + "','" + Username + "','" + Password + "','" + Email + "')";
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    clear();
                    loadData();
                    disableButton();

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
        
        public void clear()
        {
            TBUser.Text = ""; TBPass.Text = ""; TBFirstName.Text = ""; TBMiddleName.Text = ""; TBLastName.Text = ""; TBEmail.Text = "";
        }
        public void disableButton()
        {

            if (TBUser.Text == "" || TBPass.Text == "" || TBFirstName.Text == ""|| TBMiddleName.Text == ""|| TBLastName.Text == ""|| TBEmail.Text == "")
            {
                Addbutton.Enabled = false;
                
                


            }
            else
            {
                


                Addbutton.Enabled = true;

            }

        }
        public void delete(string delete2)
        {
            MySqlConnection conn1 = new MySqlConnection(connString);
            try
            {

                conn1.Open();
                string query = "DELETE FROM tbll_account WHERE id= '" + delete2 + "';"; ;
                MySqlCommand cmd = new MySqlCommand(query, conn1);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {
                    MessageBox.Show("Succesfull Deleted");
                    clear();
                    loadData();


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
        public void CheckingIfExist(String Firstname, String Middlename,String Lastname)
        {
            MySqlConnection conn1 = new MySqlConnection(connString);
            try
            {
                conn1.Open();

                string query1 = "select count(*)  from tbll_account where Firstname='" + Firstname + "' AND Middlename = '" + Middlename + "' AND Lastname = '" + Lastname + "'";
                MySqlCommand cmd1 = new MySqlCommand(query1, conn1);
                int count = Convert.ToInt32(cmd1.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("The data you want to ADD is Already Existing");


                }
                else
                {
                    Add(TBFirstName.Text,TBMiddleName.Text,TBLastName.Text,TBUser.Text,TBPass.Text,TBEmail.Text);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {
            Form HOME = new MainDashboard();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel19_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2HtmlLabel17_Click(object sender, EventArgs e)
        {
            
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            CheckingIfExist(TBFirstName.Text,TBMiddleName.Text,TBLastName.Text);
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void TBFirstName_TextChanged(object sender, EventArgs e)
        {
            disableButton();
        }

        private void TBMiddleName_TextChanged(object sender, EventArgs e)
        {
            disableButton();
        }

        private void TBLastName_TextChanged(object sender, EventArgs e)
        {
            disableButton();
        }

        private void TBEmail_TextChanged(object sender, EventArgs e)
        {
            disableButton();
        }

        private void TBUser_TextChanged(object sender, EventArgs e)
        {
            disableButton();
        }

        private void TBPass_TextChanged(object sender, EventArgs e)
        {
            disableButton();
        }

        private void toolsdt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
           

                DataGridViewCell id = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex];
                lblID.Text = id.Value.ToString();

                DataGridViewCell Tools = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                TBFirstName.Text = Tools.Value.ToString();

                DataGridViewCell Brand = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex + 6];
                TBPass.Text = Brand.Value.ToString();

                DataGridViewCell Price = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex + 2];
                TBMiddleName.Text = Price.Value.ToString();

                DataGridViewCell deadline = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex + 3];
                TBLastName.Text = deadline.Value.ToString();

                DataGridViewCell client = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex + 5];
                TBEmail.Text = client.Value.ToString();

                DataGridViewCell quantity = toolsdt.Rows[e.RowIndex].Cells[e.ColumnIndex + 4];
                TBUser.Text = quantity.Value.ToString();


            }
            */
        }

        private void guna2HtmlLabel25_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel16_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {
            Form HOME = new incident();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel9_Click_1(object sender, EventArgs e)
        {
            Form HOME = new incident();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel19_Click_1(object sender, EventArgs e)
        {
            Form HOME = new MainDashboard();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel11_Click_1(object sender, EventArgs e)
        {
            Form HOME = new Form1();
            HOME.Show();
            this.Hide();
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {
            Form HOME = new Setting();
            HOME.Show();
            this.Hide();
        }
    }
}
