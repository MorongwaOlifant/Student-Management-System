﻿namespace PRG272_GITHUB
{
    partial class ReportSummary
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelAverageAgeSummary = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(214, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(553, 363);
            this.dataGridView1.TabIndex = 9;
            // 
            // labelAverageAgeSummary
            // 
            this.labelAverageAgeSummary.AutoSize = true;
            this.labelAverageAgeSummary.Location = new System.Drawing.Point(33, 106);
            this.labelAverageAgeSummary.Name = "labelAverageAgeSummary";
            this.labelAverageAgeSummary.Size = new System.Drawing.Size(115, 13);
            this.labelAverageAgeSummary.TabIndex = 8;
            this.labelAverageAgeSummary.Text = "Average Age Summary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Students Summary";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(501, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(85, 13);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Report Summary";
            // 
            // ReportSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelAverageAgeSummary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTitle);
            this.Name = "ReportSummary";
            this.Text = "ReportSummary";
            this.Load += new System.EventHandler(this.ReportSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelAverageAgeSummary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExit;
    }
}