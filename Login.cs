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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-QH1UJOPS\SQLEXPRESS;Initial Catalog=""Grifindo Toys"";Integrated Security=True");


        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {

            Con.Open();
            string userid = txtuname.Text;
            string password = txtpw.Text;
            string sqlCom = "select UserName,Password from Login where Username='" + userid + "'and Password='" + password + "'";
            SqlCommand cmd = new SqlCommand(sqlCom, Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login success Welcome to Homepage");
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            Con.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            // Close the form when the "Cancel" button is clicked
            this.Close();
        }
    }
}
