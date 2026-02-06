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

namespace Grif
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=""Grifindo Toys"";Integrated Security=True");

        private void btncalculate_Click(object sender, EventArgs e)
        {
            // Get the start and stop dates from DateTimePicker controls.
            DateTime Start, stop;
            Start = dtpstartdate.Value;
            stop = dtpenddate.Value;

            // Calculate the time difference in days.
            TimeSpan ts = stop - Start;
            double diff = ts.Days;

            // Display the day difference in a TextBox.
            txtcycle.Text = diff.ToString();
        }

        private void btnsaveupdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the database connection is not already open
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                // Define the SQL query to update attendance-related settings in the database.
                string query = "UPDATE Attendence SET CDRate = @CDRate, Sdate = @salaryCycleStartDate, Edate = @salaryCycleEndDate, Leavesperyear = @LeavesPerYear WHERE SettingID = 1";

                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    // Set parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@CDRate", txtcycle.Text);
                    cmd.Parameters.AddWithValue("@salaryCycleStartDate", dtpstartdate.Value);
                    cmd.Parameters.AddWithValue("@salaryCycleEndDate", dtpenddate.Value);
                    cmd.Parameters.AddWithValue("@LeavesPerYear", txtleavesyear.Text);

                    // Execute the SQL command to update the database records.
                    cmd.ExecuteNonQuery();

                    // Display a success message if the update is performed without errors.
                    MessageBox.Show("Record updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle and display an error message if an exception occurs during the database operation.
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                Con.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            try
            {
                // Attempt to connect to a database.
                Con.Open();

                // Create a query to retrieve data from the "Attendence" table where SettingID is 1.
                string query = "Select * from Attendence where SettingID = 1";

                // Prepare a command to execute the query using the established database connection.
                SqlCommand cmd = new SqlCommand(query, Con);

                // Execute the command and retrieve the results.
                SqlDataReader dr = cmd.ExecuteReader();

                // Create a table to store the retrieved data.
                DataTable dt = new DataTable();

                // Check if there is data in the result set.
                if (dr.Read())
                {
                    // If data is found, populate date fields and text boxes on the form with the retrieved values.
                    dtpstartdate.Value = Convert.ToDateTime(dr["salaryCycleStartDate"]);
                    dtpenddate.Value = Convert.ToDateTime(dr["salaryCycleEndDate"]);
                    txtleavesyear.Text = dr["LeavesPerYear"].ToString();
                    txtcycle.Text = dr["salaryCycleDays"].ToString();
                }

                // Close the database connection.
                Con.Close();
            }
            catch (Exception ex)
            {
                // If an error occurs during this process, display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Home Hm = new Home();
            Hm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Employees Em = new Employees();
            Em.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Attendence At = new Attendence();
            At.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Salary Sl = new Salary();
            Sl.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // Close the current form (the main form).
            this.Close();

            // Optionally, display a login form or another form to handle new logins.
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
