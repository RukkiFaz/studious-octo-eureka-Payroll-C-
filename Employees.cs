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
    public partial class Employees : Form
    {
        public Employees()
        {
            // Call the InitializeComponent method, which initializes the components and controls of the form.
            InitializeComponent();
            // Call the ShowEmployee method to display a list of employees on the form.
            ShowEmployee();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=""Grifindo Toys"";Integrated Security=True");

        private void ShowEmployee()
        {
            // Open a connection to the database.
            Con.Open();

            // Define a SQL query to select all records from the 'EmployeeTbl' table.
            String Query = "Select * From EmployeeTbl";

            // Create a data adapter (sda) to execute the SQL query and manage data retrieval.
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);

            // Create a command builder (Builder) to automatically generate SQL commands for updating the data source.
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);

            // Create a new DataSet (ds) to hold the retrieved data.
            var ds = new DataSet();

            // Fill the DataSet (ds) with data from the database using the data adapter (sda).
            sda.Fill(ds);

            // Display the data from the first table in the DataSet in a DataGridView (empdgv).
            empdgv.DataSource = ds.Tables[0];

            // Close the database connection.
            Con.Close();


        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            // Check if any of the required input fields are empty or not selected.
            if (txtempid.Text == "" || empfname.Text == "" || emplname.Text == "" || gendercombo.SelectedIndex == -1 || txtphone.Text == "" || empadd.Text == "" || comboposition.SelectedIndex == -1 || comboqualification.SelectedIndex == -1 || txtbasesalary.Text == "" || txtot.Text == "" || txtallowances.Text == "" || txtgvttax.Text == "")
            {
                // Display a message if any required information is missing.
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    // Establish a connection to the database.
                    using (SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=Grifindo Toys;Integrated Security=True"))
                    {
                        Con.Open();

                        // Define a SQL command to insert a new employee record into the database.
                        SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeTbl(EmpID, Fname, Lname, Gender, Phone,NIC, Address, EmpPosition, DOB, JoinDate, EmpQual, EmpBaseSal, OtHours, Allowances, GvtTax) " +
                            "VALUES (@empid, @Fn, @Ln, @Gen, @Phone,@nic, @Add, @Emppos, @DOB, @Joindt, @Empq, @Empbsal, @Oth, @Allow, @Gvttx)", Con);

                        // Set parameters for the SQL command with values from the form fields.
                        cmd.Parameters.AddWithValue("@empid", txtempid.Text);
                        cmd.Parameters.AddWithValue("@Fn", empfname.Text);
                        cmd.Parameters.AddWithValue("@Ln", emplname.Text);
                        cmd.Parameters.AddWithValue("@Gen", gendercombo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cmd.Parameters.AddWithValue("@nic", txtnic.Text);
                        cmd.Parameters.AddWithValue("@Add", empadd.Text);
                        cmd.Parameters.AddWithValue("@Emppos", comboposition.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DOB", dtpdob.Value);
                        cmd.Parameters.AddWithValue("@Joindt", dtpjoindt.Value);
                        cmd.Parameters.AddWithValue("@Empq", comboqualification.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Empbsal", Convert.ToDouble(txtbasesalary.Text));
                        cmd.Parameters.AddWithValue("@Oth", Convert.ToDouble(txtot.Text));
                        cmd.Parameters.AddWithValue("@Allow", Convert.ToDouble(txtallowances.Text));
                        cmd.Parameters.AddWithValue("@Gvttx", Convert.ToDouble(txtgvttax.Text));

                        // Execute the SQL command to insert the new employee record.
                        cmd.ExecuteNonQuery();
                        // Show the updated employee list (assuming 'ShowEmployee()' does that).
                        ShowEmployee();
                    }
                    // Display a message indicating that the employee has been saved.
                    MessageBox.Show("Employee Saved");
                    Con.Close();// Close the database connection
                }

                catch (Exception ex)
                {
                    // Handle and display any exceptions that may occur during the database operation.
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            // Check if the Employee ID input is empty or consists only of white spaces.
            if (string.IsNullOrWhiteSpace(txtempid.Text))
            {
                // Display a message if the Employee ID is missing.
                MessageBox.Show("Please enter the Employee ID for the search.");
            }
            else
            {
                try
                {
                    // Open a connection to the database.
                    Con.Open();
                    // Define a SQL query to retrieve employee information based on the given Employee ID.
                    string query = "SELECT * FROM EmployeeTbl WHERE EmpID = @empid";

                    // Create a SQL command with parameters to execute the query.
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@empid", txtempid.Text);

                    // Execute the query and obtain a reader to access the result set.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if a matching employee record was found.
                    if (reader.Read())
                    {
                        // Populate form fields with employee information from the database.
                        string genderValue = reader["Gender"].ToString();
                        gendercombo.Text = genderValue;

                        empfname.Text = reader["Fname"].ToString();
                        emplname.Text = reader["Lname"].ToString();
                        txtphone.Text = reader["Phone"].ToString();
                        txtnic.Text = reader["nic"].ToString();
                        empadd.Text = reader["Address"].ToString();
                        comboposition.SelectedItem = reader["EmpPosition"].ToString();

                        // Handle Date of Birth (DOB)
                        if (reader["DOB"] != DBNull.Value)
                        {
                            if (reader["DOB"] is DateTimeOffset)
                            {
                                dtpdob.Value = ((DateTimeOffset)reader["DOB"]).DateTime;
                            }
                            else
                            {
                                dtpdob.Value = Convert.ToDateTime(reader["DOB"]);
                            }
                        }
                        else
                        {
                            dtpdob.Value = DateTime.Today; // Set a default value or handle it differently.
                        }

                        // Handle Join Date
                        if (reader["JoinDate"] != DBNull.Value)
                        {
                            if (reader["JoinDate"] is DateTimeOffset)
                            {
                                dtpjoindt.Value = ((DateTimeOffset)reader["JoinDate"]).DateTime;
                            }
                            else
                            {
                                dtpjoindt.Value = Convert.ToDateTime(reader["JoinDate"]);
                            }
                        }
                        else
                        {
                            dtpjoindt.Value = DateTime.Today; // Set a default value or handle it differently.
                        }

                        comboqualification.SelectedItem = reader["EmpQual"].ToString();
                        txtbasesalary.Text = reader["EmpBaseSal"].ToString();
                        txtot.Text = reader["OtHours"].ToString();
                        txtallowances.Text = reader["Allowances"].ToString();
                        txtgvttax.Text = reader["GvtTax"].ToString();  // Set the GvtTax text directly

                        // Display a message indicating that the employee was found.
                        MessageBox.Show("Employee found.");
                    }
                    else
                    {
                        // Display a message indicating that the employee was not found.
                        MessageBox.Show("Employee not found.");
                    }
                    // Close the database connection.
                    Con.Close();
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the database operation and display an error message.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void empdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void empdgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindo_ToysDataSet.EmployeeTbl' table. You can move, or remove it, as needed.
            this.employeeTblTableAdapter.Fill(this.grifindo_ToysDataSet.EmployeeTbl);

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Check if any of the required information fields are empty.
            if (txtempid.Text == "" || empfname.Text == "" || emplname.Text == "" || gendercombo.SelectedIndex == 0 || txtphone.Text == "" || empadd.Text == "" || comboposition.SelectedIndex == -1 || comboqualification.SelectedIndex == -1 || txtbasesalary.Text == "" || txtot.Text == "" || txtallowances.Text == "" || txtgvttax.Text == "")
            {
                // Display a message if any required information is missing.
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    // Establish a connection to the database.
                    using (SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=Grifindo Toys;Integrated Security=True"))
                    {
                        Con.Open();
                        // Create a SQL command to update employee information in the database.
                        SqlCommand cmd = new SqlCommand("UPDATE EmployeeTbl SET Fname = @Fn, Lname = @Ln, Gender = @Gen, Phone = @Phone, NIC = @nic, Address = @Add, EmpPosition = @Emppos, DOB = @DOB, JoinDate = @Joindt, EmpQual = @Empq, EmpBaseSal = @Empbsal, OtHours = @Oth, Allowances = @Allow, GvtTax = @Gvttx WHERE EmpID = @empid", Con);

                        // Set parameters for the SQL command with values from the form fields.
                        // Each parameter corresponds to a field in the database.
                        cmd.Parameters.AddWithValue("@empid", txtempid.Text);
                        cmd.Parameters.AddWithValue("@Fn", empfname.Text);
                        cmd.Parameters.AddWithValue("@Ln", emplname.Text);
                        cmd.Parameters.AddWithValue("@Gen", gendercombo.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                        cmd.Parameters.AddWithValue("@nic", txtnic.Text);
                        cmd.Parameters.AddWithValue("@Add", empadd.Text);
                        cmd.Parameters.AddWithValue("@Emppos", comboposition.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DOB", dtpdob.Value);
                        cmd.Parameters.AddWithValue("@Joindt", dtpjoindt.Value);
                        cmd.Parameters.AddWithValue("@Empq", comboqualification.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Empbsal", Convert.ToDouble(txtbasesalary.Text));
                        cmd.Parameters.AddWithValue("@Oth", Convert.ToDouble(txtot.Text));
                        cmd.Parameters.AddWithValue("@Allow", Convert.ToDouble(txtallowances.Text));
                        cmd.Parameters.AddWithValue("@Gvttx", Convert.ToDouble(txtgvttax.Text));

                        // Execute the SQL command to update employee information in the database.
                        cmd.ExecuteNonQuery();
                        // Display a success message.
                        MessageBox.Show("Employee Updated");
                        // Call a function to refresh and display the updated employee data.
                        ShowEmployee();
                    }
                    Con.Close();// The 'using' statement ensures that the connection is closed automatically
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the database operation and display an error message.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Check if the Employee ID input is empty or contains only white spaces.
            if (string.IsNullOrWhiteSpace(txtempid.Text))
            {
                // Display a message asking the user to enter an Employee ID for the delete.
                MessageBox.Show("Please enter the Employee ID for the delete.");
            }
            else
            {
                try
                {
                    // Attempt to connect to the database.
                    using (SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=""Grifindo Toys"";Integrated Security=True"))
                    {
                        Con.Open();

                        // Create a SQL command to delete an employee based on the provided Employee ID.
                        SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeTbl WHERE EmpID = @empid", Con);
                        cmd.Parameters.AddWithValue("@empid", txtempid.Text);

                        // Execute the SQL command and get the number of affected rows.
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected by the delete.
                        if (rowsAffected > 0)
                        {
                            // Display a success message if the employee was successfully deleted.
                            MessageBox.Show("Employee Deleted");
                            ShowEmployee(); // Refresh the employee data grid
                        }
                        else
                        {
                            // Indicate that the employee was not found if no rows were affected.
                            MessageBox.Show("Employee not found.");
                        }
                    }
                    Con.Close();
                }
                catch (Exception ex)
                {
                    // Handle and display an error message if an exception occurs.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {

            txtempid.Text = string.Empty;
            empfname.Text = string.Empty;
            emplname.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtnic.Text = string.Empty;
            empadd.Text = string.Empty;
            comboposition.SelectedIndex = -1;  // Clear the selection

            // Set DOB and JoinDate to DateTime.Today to clear them
            dtpdob.Value = DateTime.Today;
            dtpjoindt.Value = DateTime.Today;

            comboqualification.SelectedIndex = -1;  // Clear the selection
            txtbasesalary.Text = string.Empty;
            txtot.Text = string.Empty;
            txtallowances.Text = string.Empty;
            txtgvttax.Text = string.Empty;

            // Clear the gender combo box
            gendercombo.Text = string.Empty;
            gendercombo.SelectedItem = null;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            // Close the form
            this.Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Attendence At = new Attendence();
            At.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Salary Sl = new Salary();
            Sl.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Close the current form (the main form).
            this.Close();

            // Optionally, display a login form or another form to handle new logins.
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
