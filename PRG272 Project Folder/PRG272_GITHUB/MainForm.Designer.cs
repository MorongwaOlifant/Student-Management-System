namespace PRG272_GITHUB
{
    partial class MainForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxStudentID = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxCourse = new System.Windows.Forms.TextBox();
            this.labelAverageAge = new System.Windows.Forms.Label();
            this.labelTotalStudents = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelStudentID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStudentInfo = new System.Windows.Forms.Label();
            this.labelStudentRecordsTable = new System.Windows.Forms.Label();
            this.labelSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(79, 375);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.Size = new System.Drawing.Size(409, 142);
            this.dataGridViewStudents.TabIndex = 54;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(143, 313);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(63, 23);
            this.buttonGenerateReport.TabIndex = 52;
            this.buttonGenerateReport.Text = "Generate Report";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(305, 313);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(63, 23);
            this.buttonDelete.TabIndex = 51;
            this.buttonDelete.Text = "Delete Student";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(143, 255);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(63, 23);
            this.buttonUpdate.TabIndex = 50;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(305, 255);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(63, 23);
            this.buttonAdd.TabIndex = 49;
            this.buttonAdd.Text = "Add Student\t";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(151, 137);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(122, 20);
            this.textBoxName.TabIndex = 48;
            // 
            // textBoxStudentID
            // 
            this.textBoxStudentID.Location = new System.Drawing.Point(151, 104);
            this.textBoxStudentID.Name = "textBoxStudentID";
            this.textBoxStudentID.Size = new System.Drawing.Size(122, 20);
            this.textBoxStudentID.TabIndex = 47;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(151, 168);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(122, 20);
            this.textBoxAge.TabIndex = 46;
            // 
            // textBoxCourse
            // 
            this.textBoxCourse.Location = new System.Drawing.Point(151, 196);
            this.textBoxCourse.Name = "textBoxCourse";
            this.textBoxCourse.Size = new System.Drawing.Size(122, 20);
            this.textBoxCourse.TabIndex = 45;
            // 
            // labelAverageAge
            // 
            this.labelAverageAge.AutoSize = true;
            this.labelAverageAge.Location = new System.Drawing.Point(63, 631);
            this.labelAverageAge.Name = "labelAverageAge";
            this.labelAverageAge.Size = new System.Drawing.Size(72, 13);
            this.labelAverageAge.TabIndex = 44;
            this.labelAverageAge.Text = "Average Age:\t";
            // 
            // labelTotalStudents
            // 
            this.labelTotalStudents.AutoSize = true;
            this.labelTotalStudents.Location = new System.Drawing.Point(63, 571);
            this.labelTotalStudents.Name = "labelTotalStudents";
            this.labelTotalStudents.Size = new System.Drawing.Size(79, 13);
            this.labelTotalStudents.TabIndex = 43;
            this.labelTotalStudents.Text = "Total Students:\t";
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Location = new System.Drawing.Point(99, 199);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(43, 13);
            this.labelCourse.TabIndex = 41;
            this.labelCourse.Text = "Course:\t";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(113, 175);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(29, 13);
            this.labelAge.TabIndex = 40;
            this.labelAge.Text = "Age:\t";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(104, 144);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 39;
            this.labelName.Text = "Name:\t";
            // 
            // labelStudentID
            // 
            this.labelStudentID.AutoSize = true;
            this.labelStudentID.Location = new System.Drawing.Point(81, 111);
            this.labelStudentID.Name = "labelStudentID";
            this.labelStudentID.Size = new System.Drawing.Size(61, 13);
            this.labelStudentID.TabIndex = 38;
            this.labelStudentID.Text = "Student ID:\t";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 55;
            // 
            // labelStudentInfo
            // 
            this.labelStudentInfo.AutoSize = true;
            this.labelStudentInfo.Location = new System.Drawing.Point(215, 29);
            this.labelStudentInfo.Name = "labelStudentInfo";
            this.labelStudentInfo.Size = new System.Drawing.Size(99, 13);
            this.labelStudentInfo.TabIndex = 56;
            this.labelStudentInfo.Text = "Student Information\t";
            // 
            // labelStudentRecordsTable
            // 
            this.labelStudentRecordsTable.AutoSize = true;
            this.labelStudentRecordsTable.Location = new System.Drawing.Point(217, 352);
            this.labelStudentRecordsTable.Name = "labelStudentRecordsTable";
            this.labelStudentRecordsTable.Size = new System.Drawing.Size(117, 13);
            this.labelStudentRecordsTable.TabIndex = 57;
            this.labelStudentRecordsTable.Text = "Student Records Table";
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(215, 533);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(85, 13);
            this.labelSummary.TabIndex = 58;
            this.labelSummary.Text = "Summary Report\t";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 717);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.labelStudentRecordsTable);
            this.Controls.Add(this.labelStudentInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxStudentID);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxCourse);
            this.Controls.Add(this.labelAverageAge);
            this.Controls.Add(this.labelTotalStudents);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelStudentID);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxStudentID;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxCourse;
        private System.Windows.Forms.Label labelAverageAge;
        private System.Windows.Forms.Label labelTotalStudents;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelStudentID;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStudentInfo;
        private System.Windows.Forms.Label labelStudentRecordsTable;
        private System.Windows.Forms.Label labelSummary;
    }
}