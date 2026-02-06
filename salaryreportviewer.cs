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
    public partial class salaryreportviewer : Form
    {
        public salaryreportviewer()
        {
            InitializeComponent();
        }

        private void salaryreportviewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'grifindo_ToysDataSet2.SalaryTbl' table. You can move, or remove it, as needed.
            this.salaryTblTableAdapter.Fill(this.grifindo_ToysDataSet2.SalaryTbl);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Home Hm = new Home();
            Hm.Show();
            this.Hide();
        }
    }
}
