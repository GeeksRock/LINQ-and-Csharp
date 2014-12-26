namespace LinqToObjects
{
    partial class Form1
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
            this.label3 = new System.Windows.Forms.Label();
            this.lnkAboutDemo = new System.Windows.Forms.LinkLabel();
            this.dgvChickens = new System.Windows.Forms.DataGridView();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkFilterInfo = new System.Windows.Forms.LinkLabel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblQueryCount = new System.Windows.Forms.Label();
            this.lnkReset = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChickens)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chicken Breed Data";
            // 
            // lnkAboutDemo
            // 
            this.lnkAboutDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkAboutDemo.AutoSize = true;
            this.lnkAboutDemo.Location = new System.Drawing.Point(16, 563);
            this.lnkAboutDemo.Name = "lnkAboutDemo";
            this.lnkAboutDemo.Size = new System.Drawing.Size(83, 13);
            this.lnkAboutDemo.TabIndex = 16;
            this.lnkAboutDemo.TabStop = true;
            this.lnkAboutDemo.Tag = "About this demo";
            this.lnkAboutDemo.Text = "About this demo";
            this.lnkAboutDemo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAboutDemo_LinkClicked);
            // 
            // dgvChickens
            // 
            this.dgvChickens.AllowUserToAddRows = false;
            this.dgvChickens.AllowUserToDeleteRows = false;
            this.dgvChickens.AllowUserToOrderColumns = true;
            this.dgvChickens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChickens.Location = new System.Drawing.Point(19, 27);
            this.dgvChickens.Name = "dgvChickens";
            this.dgvChickens.Size = new System.Drawing.Size(865, 506);
            this.dgvChickens.TabIndex = 0;
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(266, 556);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(582, 20);
            this.txtQuery.TabIndex = 17;
            this.txtQuery.Text = "Purpose:Egg-laying,Dual;EggLaying:Good,Very Good,Excellent";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 563);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Filter:";
            // 
            // lnkFilterInfo
            // 
            this.lnkFilterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkFilterInfo.AutoSize = true;
            this.lnkFilterInfo.Location = new System.Drawing.Point(219, 563);
            this.lnkFilterInfo.Name = "lnkFilterInfo";
            this.lnkFilterInfo.Size = new System.Drawing.Size(13, 13);
            this.lnkFilterInfo.TabIndex = 19;
            this.lnkFilterInfo.TabStop = true;
            this.lnkFilterInfo.Tag = "About filtering";
            this.lnkFilterInfo.Text = "?";
            this.lnkFilterInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFilterInfo_LinkClicked);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.AutoSize = true;
            this.btnFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFilter.Location = new System.Drawing.Point(861, 553);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(23, 23);
            this.btnFilter.TabIndex = 20;
            this.btnFilter.Text = "F";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblQueryCount
            // 
            this.lblQueryCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQueryCount.AutoSize = true;
            this.lblQueryCount.ForeColor = System.Drawing.Color.Blue;
            this.lblQueryCount.Location = new System.Drawing.Point(725, 10);
            this.lblQueryCount.Name = "lblQueryCount";
            this.lblQueryCount.Size = new System.Drawing.Size(144, 13);
            this.lblQueryCount.TabIndex = 21;
            this.lblQueryCount.Text = "Number of records displayed:";
            // 
            // lnkReset
            // 
            this.lnkReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkReset.AutoSize = true;
            this.lnkReset.Location = new System.Drawing.Point(102, 563);
            this.lnkReset.Name = "lnkReset";
            this.lnkReset.Size = new System.Drawing.Size(83, 13);
            this.lnkReset.TabIndex = 22;
            this.lnkReset.TabStop = true;
            this.lnkReset.Text = "Reset this demo";
            this.lnkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReset_LinkClicked);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 585);
            this.Controls.Add(this.lnkReset);
            this.Controls.Add(this.lblQueryCount);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lnkFilterInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.dgvChickens);
            this.Controls.Add(this.lnkAboutDemo);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Portfolio Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChickens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkAboutDemo;
        private System.Windows.Forms.DataGridView dgvChickens;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkFilterInfo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblQueryCount;
        private System.Windows.Forms.LinkLabel lnkReset;
    }
}

