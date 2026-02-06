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
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Hide the current form (Home page)
            this.Hide();

            // Create an instance of the Login form
            Login loginForm = new Login();

            // Show the Login form.
            loginForm.Show();
        }
    }
}
