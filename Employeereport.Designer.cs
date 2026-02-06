namespace Grif
{
    partial class Employeereport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.salaryTblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grifindo_ToysDataSet1 = new Grif.Grifindo_ToysDataSet1();
            this.txtempid = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnvwreport = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.salaryTblTableAdapter = new Grif.Grifindo_ToysDataSet1TableAdapters.SalaryTblTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.salaryTblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindo_ToysDataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // salaryTblBindingSource
            // 
            this.salaryTblBindingSource.DataMember = "SalaryTbl";
            this.salaryTblBindingSource.DataSource = this.grifindo_ToysDataSet1;
            // 
            // grifindo_ToysDataSet1
            // 
            this.grifindo_ToysDataSet1.DataSetName = "Grifindo_ToysDataSet1";
            this.grifindo_ToysDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtempid
            // 
            this.txtempid.Location = new System.Drawing.Point(146, 34);
            this.txtempid.Multiline = true;
            this.txtempid.Name = "txtempid";
            this.txtempid.Size = new System.Drawing.Size(182, 29);
            this.txtempid.TabIndex = 78;
            this.txtempid.TextChanged += new System.EventHandler(this.txtempid_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 22);
            this.label21.TabIndex = 77;
            this.label21.Text = "Employee ID";
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(347, 34);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(130, 32);
            this.btnsearch.TabIndex = 76;
            this.btnsearch.Text = "SEARCH";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.txtempid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 99);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnvwreport);
            this.groupBox2.Location = new System.Drawing.Point(548, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 85);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Salary";
            // 
            // btnvwreport
            // 
            this.btnvwreport.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvwreport.Location = new System.Drawing.Point(159, 21);
            this.btnvwreport.Name = "btnvwreport";
            this.btnvwreport.Size = new System.Drawing.Size(130, 54);
            this.btnvwreport.TabIndex = 169;
            this.btnvwreport.Text = "VIEW REPORT";
            this.btnvwreport.UseVisualStyleBackColor = true;
            this.btnvwreport.Click += new System.EventHandler(this.btnvwreport_Click);
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.salaryTblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Grif.Reportemployee.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(22, 117);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1292, 680);
            this.reportViewer1.TabIndex = 79;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // salaryTblTableAdapter
            // 
            this.salaryTblTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(892, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 56);
            this.label2.TabIndex = 81;
            this.label2.Text = "GRIFINDO TOYS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Grif.Properties.Resources.icons8_home_64;
            this.pictureBox1.Location = new System.Drawing.Point(1292, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Employeereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1369, 799);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Employeereport";
            this.Text = "Employeereport";
            this.Load += new System.EventHandler(this.Employeereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryTblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindo_ToysDataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtempid;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnvwreport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Grifindo_ToysDataSet1 grifindo_ToysDataSet1;
        private System.Windows.Forms.BindingSource salaryTblBindingSource;
        private Grifindo_ToysDataSet1TableAdapters.SalaryTblTableAdapter salaryTblTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}