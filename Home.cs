using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grif
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employees Em = new Employees();
            Em.Show();
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
