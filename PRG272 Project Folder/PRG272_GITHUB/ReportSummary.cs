using PRG272_GITHUB.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG272_GITHUB
{
    public partial class ReportSummary : Form
    {
        private readonly DataHandler _dataHandler;
        private Button buttonDeleteReport; // Declare the delete button
        public ReportSummary(DataHandler dataHandler)
        {
            InitializeComponent();
            _dataHandler = dataHandler;
            CustomizeForm();
        }
        private void CustomizeForm()
        {

            // General form styling
            this.FormBorderStyle = FormBorderStyle.None; // Borderless for modern look
            this.BackColor = Color.Gainsboro;
            this.Padding = new Padding(10);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title label styling
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(30, 30, 30);
            labelTitle.TextAlign = ContentAlignment.TopCenter;

            // Total students and average age label styling
            label2.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(70, 70, 70);
            labelAverageAgeSummary.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            labelAverageAgeSummary.ForeColor = Color.FromArgb(70, 70, 70);

            // DataGridView styling
            dataGridView1.Padding = new Padding(20, 0, 0, 0);
            dataGridView1.BackgroundColor = Color.White; // Use your DataGridView name here
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false; // Optional: prevent multiple selections

            // Add the delete button
            buttonDeleteReport = new Button
            {
                Text = "Delete Report",
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(50, 150, 250),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, this.Height - 90) // Adjust the position as needed
            };
            buttonDeleteReport.FlatAppearance.BorderSize = 0;

            // Hover effect
            buttonDeleteReport.MouseEnter += (sender, e) => buttonDeleteReport.BackColor = Color.FromArgb(30, 130, 230);
            buttonDeleteReport.MouseLeave += (sender, e) => buttonDeleteReport.BackColor = Color.FromArgb(50, 150, 250);

            buttonDeleteReport.Click += buttonDeleteReport_Click; // Add event handler
            this.Controls.Add(buttonDeleteReport);

            // Add the exit button
            buttonExit = new Button
            {
                Text = "X", // Exit button text
                Location = new Point(this.Width - 50, 10), // Positioning the exit button at the top-right
                Size = new Size(40, 30),
                BackColor = Color.Red, // Optional: Change color for visibility
                ForeColor = Color.White // Text color
            };
            buttonExit.Click += buttonExit_Click; // Adding the click event handler
            this.Controls.Add(buttonExit);


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form when the exit button is clicked
        }
        private void ReportSummary_Load(object sender, EventArgs e)
        {
            LoadReportSummaryData();
            DisplaySummaryStatistics();
        }

        private void LoadReportSummaryData()
        {
            try
            {
                // Fetch report summary data from the database
                DataTable reportData = _dataHandler.GetReportSummaryData();

                // Bind data to the DataGridView
                dataGridView1.DataSource = reportData;

                // Format DataGridView if needed
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load report summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplaySummaryStatistics()
        {
            try
            {
                // Get total students and average age
                int totalStudents = _dataHandler.GetTotalStudents();
                double averageAge = _dataHandler.GetAverageAge();

                // Display the values in labels
                label2.Text = $"Total Students: {totalStudents}";
                labelAverageAgeSummary.Text = $"Average Age: {averageAge:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve summary statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteReport_Click(object sender, EventArgs e)
        {
            DeleteSelectedReport();
        }
        private void DeleteSelectedReport()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Assuming the DataGridView has a column named "ReportID" which is the unique identifier
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int reportID = Convert.ToInt32(selectedRow.Cells["ReportID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this report?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Delete the report
                    bool success = _dataHandler.DeleteReport(reportID);
                    if (success)
                    {
                        MessageBox.Show("Report deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReportSummaryData(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a report to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
