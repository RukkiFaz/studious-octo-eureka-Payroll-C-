using Microsoft.Reporting.WinForms;
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
    public partial class Employeereport : Form
    {
        public Employeereport()
        {
            InitializeComponent();
        }

        private void btnvwreport_Click(object sender, EventArgs e)
        {
            salaryreportviewer Home = new salaryreportviewer();
            Home.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=Grifindo Toys;Integrated Security=True"))
                {
                    Con.Open();

                    // Fetch salary data for a specific employee
                    string selectQuery = "SELECT * FROM SalaryTbl WHERE EmpID = @empid";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, Con);
                    selectCmd.Parameters.AddWithValue("@empid", txtempid.Text);

                    SqlDataReader reader = selectCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Create a DataTable to hold the data
                        System.Data.DataTable dataTable = new System.Data.DataTable();
                        dataTable.Load(reader);

                        // Set the report data source
                        reportViewer1.LocalReport.ReportPath = "C:\\Users\\ruksh\\Desktop\\Grif\\Reportemployee.rdlc"; // Replace with your report file name
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataTable)); // Replace with your dataset name

                        // Refresh the report viewer
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No salary data found for the specified employee.");
                    }

                    // Close the SqlDataReader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Employeereport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindo_ToysDataSet1.SalaryTbl' table. You can move, or remove it, as needed.
            this.salaryTblTableAdapter.Fill(this.grifindo_ToysDataSet1.SalaryTbl);

            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ruksh\\Desktop\\Grif\\Reportemployee.rdlc";
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void txtempid_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Home Hm = new Home();
            Hm.Show();
            this.Hide();
        }
    }
}
