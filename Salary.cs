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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=""Grifindo Toys"";Integrated Security=True");
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtempid.Text))
            {
                // Check if the Employee ID input is empty or contains only whitespace
                MessageBox.Show("Please enter the Employee ID for the search.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "SELECT * FROM EmployeeTbl WHERE EmpID = @empid";
                    // Open a database connection and prepare a SQL query

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@empid", txtempid.Text);
                    // Create a parameterized SQL command to search for an employee by ID

                    SqlDataReader reader = cmd.ExecuteReader();
                    // Execute the query and obtain a reader to read the results

                    if (reader.Read())
                    {
                        // If a matching employee is found
                        empfname.Text = reader["Fname"].ToString();
                        emplname.Text = reader["Lname"].ToString();
                        txtmonsal.Text = reader["EmpBaseSal"].ToString();

                        string gvtTaxValue = reader["GvtTax"].ToString();
                        Console.WriteLine("GvtTax Value: " + gvtTaxValue);
                        // Retrieve and display employee information

                        txtott.Text = reader["OtHours"].ToString();
                        txtallowances.Text = reader["Allowances"].ToString();
                        txtgvttax.Text = gvtTaxValue;  // Set the GvtTax text directly

                        MessageBox.Show("Employee found.");
                    }
                    else
                    {
                        // If the employee is not found
                        MessageBox.Show("Employee not found.");
                    }

                    Con.Close();
                    // Close the database connection when done
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database operations
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                // Clear all the textboxes
                txtsalid.Clear();
                txtempid.Clear();
                txtbasepay.Clear();
                txtallowances.Clear();
                txtot.Clear();
                txtnopay.Clear();
                txtgvttax.Clear();
                txtgrosspay.Clear();
                txtpayrollid.Clear();

                empfname.Clear();
                emplname.Clear();
                txtholiday.Clear();
                txtleave.Clear();
                txtabsent.Clear();
                txtholiday.Clear();
                txtothours.Clear();
                txtoveratt.Clear();
                txtcycle.Clear();
                txtleavesyear.Clear();
                txtmonsal.Clear();
                txtott.Clear();

                // Clear the DateTimePickers
                dtppaymentdt.Value = DateTime.Now;
                dtpstartdate.Value = DateTime.Now;
                dtpenddate.Value = DateTime.Now;
            }

        }

        private void btnvalidate_Click(object sender, EventArgs e)
        {
            try
            {
                // Try to open a connection to the database
                Con.Open();
                // Define the SQL query to retrieve data with SettingID = 1
                string query = "SELECT * FROM Attendence WHERE SettingID = 1";

                // Create a command to execute the query
                SqlCommand cmd = new SqlCommand(query, Con);

                // Execute the query and get the results
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Define variables to store database values
                    DateTimeOffset databaseSdate;
                    DateTimeOffset databaseEdate;
                    string databaseLeavesperyear = dr["Leavesperyear"].ToString();
                    string databaseCDRate = dr["CDRate"].ToString();

                    // Try to parse the date values from the database
                    if (DateTimeOffset.TryParse(dr["Sdate"].ToString(), out databaseSdate) &&
                        DateTimeOffset.TryParse(dr["Edate"].ToString(), out databaseEdate))
                    {
                        // Convert the DateTimeOffset to DateTime
                        DateTime selectedStartDate = databaseSdate.DateTime;
                        DateTime selectedEndDate = databaseEdate.DateTime;

                        // Try to parse the user input as integers
                        if (int.TryParse(txtleavesyear.Text, out int selectedLeavesPerYear) &&
                            int.TryParse(txtcycle.Text, out int selectedCDRate))
                        {
                            // Compare the parsed values

                            // Check if the selected start and end dates match the database
                            if (selectedStartDate == databaseSdate.DateTime &&
                                selectedEndDate == databaseEdate.DateTime &&
                                // Check if the selected numeric values match the database
                                selectedLeavesPerYear == int.Parse(databaseLeavesperyear) &&
                                selectedCDRate == int.Parse(databaseCDRate))
                            {
                                // If all conditions are met, show a success message
                                MessageBox.Show("Selected values are correct", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // If the conditions are not met, show an invalid selection message
                                MessageBox.Show("Invalid Selection", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // If numeric input cannot be parsed, show an error message
                            MessageBox.Show("Please enter valid numeric values in Leaves Per Year and Cycle Date Range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // If date parsing from the database fails, show a date parsing error message
                        MessageBox.Show("Date parsing error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, show an error message with the exception details
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure that the database connection is closed, even if an exception occurs
                Con.Close();
            }

        }

            
    

        private void btncal_Click(object sender, EventArgs e)
        {
            try
            {
                // Variable declaration
                float overtime, nopay, monthlysal, overallattendance, cycledaterange,
                    absentdays, basepay, allowance, otrate, othrs, grosspay, taxrate;

                // Parse input values
                overallattendance = float.Parse(txtoveratt.Text);
                cycledaterange = float.Parse(txtcycle.Text);
                absentdays = float.Parse(txtabsent.Text);
                monthlysal = float.Parse(txtmonsal.Text);

                // NOPAY CALCULATION
                MessageBox.Show("monthlysal: " + monthlysal.ToString());
                MessageBox.Show("cycledaterange: " + cycledaterange.ToString());
                MessageBox.Show("absentdays: " + absentdays.ToString());

                if (overallattendance >= cycledaterange)
                {
                    // Handle the case when overallattendance is greater than or equal to cycledaterange.
                    nopay = 0; // Set nopay to 0 or handle it as needed.
                    txtnopay.Text = nopay.ToString();
                }
                else
                {
                    nopay = (monthlysal / cycledaterange) * absentdays;
                    txtnopay.Text = nopay.ToString();
                }

                // BASE PAY CALCULATION
                allowance = float.Parse(txtallowances.Text);
                otrate = float.Parse(txtott.Text);
                othrs = float.Parse(txtothours.Text);
                overtime = othrs * otrate;
                basepay = monthlysal + allowance + overtime;
                txtbasepay.Text = basepay.ToString();
                txtot.Text = overtime.ToString();

                // GROSS PAY CALCULATION
                taxrate = float.Parse(txtgvttax.Text) / 100; // Assuming tax rate is provided as a percentage
                nopay = float.Parse(txtnopay.Text);
                float taxAmount = basepay * taxrate;
                grosspay = basepay - (nopay + taxAmount);
                txtgrosspay.Text = grosspay.ToString();
            }
            catch (FormatException ex)
            {
                // Catch and handle exceptions related to input formatting errors.
                // This block is executed when the input string cannot be parsed as a valid floating-point number.
                // You can display an error message to the user to inform them about the incorrect input format.
                MessageBox.Show("Input format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btncsalary_Click(object sender, EventArgs e)
        {
            // Try to insert salary data into a database.
            try
            {
                // Open a connection to the database.
                using (SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=Grifindo Toys;Integrated Security=True"))
                {
                    Con.Open();

                       
                        string insertQuery = "INSERT INTO SalaryTbl (SalaryID, Fname, Lname, EmpID, LeavesTaken, Absent, HolidaysTaken, OtHours, Overallatt, Sdate, Edate, CDRate, Leavesperyear, BasePay, Allowances, Overtime, Nopay, GvtTax, GrossPay, PayrollID, PaymentDate, MonthlySalary, OTHourly) " +
                            "VALUES (@salid, @fname, @lname, @empid, @leavestaken, @absent, @holidays, @othours, @overallatt, @sdate, @edate, @cdr, @leaves, @basepay, @allowance, @overtime, @nopay, @taxrate, @grosspay, @payrollid, @paymentdt, @monthlysalary, @othourly)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, Con);


                        // Set parameters for the insertCmd using user inputs.
                        insertCmd.Parameters.AddWithValue("@salid", txtsalid.Text); // Salary ID
                        insertCmd.Parameters.AddWithValue("@empid", txtempid.Text); // Employee ID
                        insertCmd.Parameters.AddWithValue("@basepay", txtbasepay.Text); // Base Pay
                        insertCmd.Parameters.AddWithValue("@allowance", txtallowances.Text); // Allowances
                        insertCmd.Parameters.AddWithValue("@overtime", Convert.ToDouble(txtot.Text)); // Overtime
                        insertCmd.Parameters.AddWithValue("@nopay", Convert.ToDouble(txtnopay.Text)); // Nopay
                        insertCmd.Parameters.AddWithValue("@taxrate", Convert.ToDouble(txtgvttax.Text)); // GvtTax
                        insertCmd.Parameters.AddWithValue("@grosspay", Convert.ToDouble(txtgrosspay.Text)); // Gross Pay
                        insertCmd.Parameters.AddWithValue("@payrollid", txtpayrollid.Text); // Payroll ID
                        insertCmd.Parameters.AddWithValue("@paymentdt", dtppaymentdt.Value); // Payment Date

                        // Additional parameters
                        insertCmd.Parameters.AddWithValue("@fname", empfname.Text); // First Name
                        insertCmd.Parameters.AddWithValue("@lname", emplname.Text); // Last Name
                        insertCmd.Parameters.AddWithValue("@leavestaken", Convert.ToInt32(txtholiday.Text)); // Leaves Taken
                        insertCmd.Parameters.AddWithValue("@absent", Convert.ToInt32(txtabsent.Text)); // absent
                        insertCmd.Parameters.AddWithValue("@holidays", Convert.ToInt32(txtholiday.Text)); // Holidays Taken
                        insertCmd.Parameters.AddWithValue("@othours", txtothours.Text); // OT Hours
                        insertCmd.Parameters.AddWithValue("@overallatt", Convert.ToInt32(txtoveratt.Text)); // Overall Attendance
                        insertCmd.Parameters.AddWithValue("@sdate", dtpstartdate.Value); // Start Date
                        insertCmd.Parameters.AddWithValue("@edate", dtpenddate.Value); // End Date
                        insertCmd.Parameters.AddWithValue("@cdr", txtcycle.Text); // CD Rate
                        insertCmd.Parameters.AddWithValue("@leaves", txtleavesyear.Text); // Leaves Per Year
                        insertCmd.Parameters.AddWithValue("@monthlysalary", txtmonsal.Text); // Monthly Salary
                        insertCmd.Parameters.AddWithValue("@othourly", txtott.Text); // OT Hourly Rate


                        // Execute the SQL insert command and get the number of affected rows
                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        // Check if any rows were successfully inserted
                        if (rowsAffected > 0)
                        {
                            // Display a success message if data is inserted
                            MessageBox.Show("Salary data has been confirmed and saved to the database.");
                        }
                        else
                        {
                            // Display an error message if no data is inserted
                            MessageBox.Show("Failed to insert salary data into the database.");
                        }
                    }
                
                // Close the database connection
                Con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the database operation
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnvwreport_Click(object sender, EventArgs e)
        {
            Employeereport Home = new Employeereport();
            Home.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            // Close the form
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Close the current form (the main form).
            this.Close();

            // Optionally, display a login form or another form to handle new logins.
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Salary Sl = new Salary();
            Sl.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Attendence At = new Attendence();
            At.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employees Em = new Employees();
            Em.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home Hm = new Home();
            Hm.Show();
            this.Hide();
        }
    }
}
