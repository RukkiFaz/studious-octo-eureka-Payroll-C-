namespace Grif
{
    partial class salaryreportviewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.salaryTblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grifindo_ToysDataSet2 = new Grif.Grifindo_ToysDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.grifindo_ToysDataSet = new Grif.Grifindo_ToysDataSet();
            this.grifindoToysDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryTblTableAdapter = new Grif.Grifindo_ToysDataSet2TableAdapters.SalaryTblTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.salaryTblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindo_ToysDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindo_ToysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindoToysDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // salaryTblBindingSource
            // 
            this.salaryTblBindingSource.DataMember = "SalaryTbl";
            this.salaryTblBindingSource.DataSource = this.grifindo_ToysDataSet2;
            // 
            // grifindo_ToysDataSet2
            // 
            this.grifindo_ToysDataSet2.DataSetName = "Grifindo_ToysDataSet2";
            this.grifindo_ToysDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.salaryTblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Grif.SalaryReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 106);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1327, 575);
            this.reportViewer1.TabIndex = 0;
            // 
            // grifindo_ToysDataSet
            // 
            this.grifindo_ToysDataSet.DataSetName = "Grifindo_ToysDataSet";
            this.grifindo_ToysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grifindoToysDataSetBindingSource
            // 
            this.grifindoToysDataSetBindingSource.DataSource = this.grifindo_ToysDataSet;
            this.grifindoToysDataSetBindingSource.Position = 0;
            // 
            // salaryTblTableAdapter
            // 
            this.salaryTblTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Grif.Properties.Resources.icons8_home_64;
            this.pictureBox1.Location = new System.Drawing.Point(1223, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // salaryreportviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1328, 682);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "salaryreportviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "salaryreportviewer";
            this.Load += new System.EventHandler(this.salaryreportviewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salaryTblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindo_ToysDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindo_ToysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grifindoToysDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource grifindoToysDataSetBindingSource;
        private Grifindo_ToysDataSet grifindo_ToysDataSet;
        private Grifindo_ToysDataSet2 grifindo_ToysDataSet2;
        private System.Windows.Forms.BindingSource salaryTblBindingSource;
        private Grifindo_ToysDataSet2TableAdapters.SalaryTblTableAdapter salaryTblTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}