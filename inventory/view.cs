using Guna.UI2.WinForms.Suite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace inventory
{
    public partial class view : Form
    {
        public view()
        {
            InitializeComponent();
            getdata();
        }

        public string connString = "datasource=localhost;username=root;password=;database=db_hccpod1";

        public void showdata(string course, string identity, string description, string address, string date, string time, string phone, string location,string name)
        {
            string Fname = Class1.Fname;

            lblFullname.Text = name;
            lblCourse.Text = course;
            lblAddress.Text = address;
            lblcellphoneNumber.Text = phone;
            lbldate.Text = date;
            lblTime.Text = time;
            txtiden2.Text = identity;
            txtdescription.Text = description;
            txtlocation.Text = location;
            lblname.Text = name;
        }

        public void getdata()
        {
            
            using (MySqlConnection conn1 = new MySqlConnection(connString))
            {
                try
                {
                    conn1.Open();
                    string sqlquery = "SELECT * FROM tbl_incidentdata WHERE fullname = @fName";

                    using (MySqlCommand command = new MySqlCommand(sqlquery, conn1))
                    {
                        command.Parameters.AddWithValue("@fName", Class1.Fname);

                        using (MySqlDataReader sReader = command.ExecuteReader())
                        {
                            while (sReader.Read())
                            {
                                // Retrieve data from the database
                                string course = sReader["course_year_section"].ToString();
                                string identity = sReader["identity"].ToString();
                                string location = sReader["incident_location"].ToString();
                                string address = sReader["home_address"].ToString();
                                string date = sReader["incident_date"].ToString();
                                string time = sReader["incident_time"].ToString();
                                string phone = sReader["phone_number"].ToString();
                                string description = sReader["incident_description"].ToString();
                                string name = sReader["fullname"].ToString();

                                showdata(course, identity, description, address, date, time, phone, location,name);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Update(string fullname, string address, string course, string phone, string date, string time, string iden, string description, string location, string name)
        {
            MySqlConnection conn1 = new MySqlConnection(connString);
            try
            {
                conn1.Open();
                
                string query = "UPDATE tbl_incidentdata SET fullname = '" + fullname + "',home_address = '" + address + "', course_year_section ='" + course + "' ,phone_number ='" + phone + "' ,incident_date ='" + date + "' ,incident_time ='" + time + "' ,identity ='" + iden + "'  ,incident_description ='" + description + "' ,incident_location ='" + location + "' WHERE fullname = '" + name + "' ";

                MySqlCommand cmd = new MySqlCommand(query, conn1);
                int check = cmd.ExecuteNonQuery();
                if (check > 0)
                {

                    MessageBox.Show("Sucessfully Updated");
                    getdata();


                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
                
                conn1.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form HOME = new incident();
            HOME.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            Update(lblFullname.Text,
                   lblCourse.Text,
                   lblAddress.Text,
                   lblcellphoneNumber.Text,
                   lbldate.Text,
                   lblTime.Text,
                   txtiden2.Text,
                   txtdescription.Text,
                   txtlocation.Text,Class1.Fname);
        }

        private void lblFullname_TextChanged(object sender, EventArgs e)
        {
            lblname.Text = lblFullname.Text;
        }
    }
}
