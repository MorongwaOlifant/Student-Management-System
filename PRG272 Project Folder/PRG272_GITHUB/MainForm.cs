using PRG272_GITHUB.Models;
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
using System.Data.SqlClient;

namespace PRG272_GITHUB
{
    public partial class MainForm : Form
    {
        private readonly DataHandler dataHandler;
        private Panel mainPanel;
        private FlowLayoutPanel mainFlowLayout; // Declare here
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private string placeholderText = "Search by Name or Course"; // Declare placeholderText here
        public MainForm(DataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;

            // Initialize and configure the main panel
            mainPanel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            this.Controls.Add(mainPanel);

            // Initialize and add controls to mainPanel
            InitializeControls();

            // Customize the form
            CustomizeForm();

            // Load student data
            LoadStudents();

            // Center the main panel on form load and resize
            this.Resize += (sender, e) => CenterMainPanel();
            CenterMainPanel();

            // Sync Student.txt with the database at startup
            dataHandler.SaveStudentsToFile();
            LoadStudents();

            // Attach the SelectionChanged event
            dataGridViewStudents.SelectionChanged += DataGridViewStudents_SelectionChanged;
            this.MouseDown += MainForm_MouseDown; // Attach the form mouse down event
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (!dataGridViewStudents.Focused)
            {
                ClearStudentInformation();
            }
        }

        private void CenterMainPanel()
        {
            // Center the main panel within the form
            mainPanel.Location = new Point(
                (this.ClientSize.Width - mainPanel.Width) / 2,
                (this.ClientSize.Height - mainPanel.Height) / 2
            );
        }

        private void InitializeControls()
        {

            // Search TextBox
            textBoxSearch = new TextBox { Width = 200 };
            SetPlaceholderText(textBoxSearch, "Search by Name or Course"); // Set placeholder
            buttonSearch = new Button { Text = "Search / Clear", Width = 100 };
            buttonSearch.Click += buttonSearch_Click; // Add event handler for search button
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.ForeColor = Color.Black;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            textBoxSearch.TextAlign = HorizontalAlignment.Left;


            textBoxSearch.Margin = new Padding(0);
            buttonSearch.Margin = new Padding(10);

            // Create a FlowLayoutPanel for the search controls if not already created
            FlowLayoutPanel searchLayout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };


            // Initialize the Search Button with a Modern Look





            // Customize labels using a helper method
            CustomizeLabel(labelTitle, "Student Management System", new Font("Segoe UI", 20, FontStyle.Bold), Color.FromArgb(30, 30, 30));
            CustomizeLabel(labelStudentInfo, "Student Information", new Font("Segoe UI", 15, FontStyle.Bold), Color.Black);
            CustomizeLabel(labelStudentRecordsTable, "Student Records", new Font("Segoe UI", 15, FontStyle.Bold), Color.Black);
            CustomizeLabel(labelSummary, "Summary", new Font("Segoe UI", 20, FontStyle.Bold), Color.MidnightBlue);
            CustomizeLabel(labelTotalStudents, "Total Students:", new Font("Segoe UI", 12, FontStyle.Bold), Color.DarkGreen);
            CustomizeLabel(labelAverageAge, "Average Age:", new Font("Segoe UI", 12, FontStyle.Bold), Color.Red);

            // Customize text boxes
            textBoxStudentID.Width = 200;
            textBoxName.Width = 200;
            textBoxAge.Width = 200;
            textBoxCourse.Width = 200;

            // Set up TableLayoutPanel for labels and text boxes with spacing
            TableLayoutPanel infoLayout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 4,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            infoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            infoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            // Add labels and text boxes to infoLayout with spacing
            infoLayout.Controls.Add(labelStudentID, 0, 0);
            infoLayout.Controls.Add(textBoxStudentID, 1, 0);
            infoLayout.Controls.Add(labelName, 0, 1);
            infoLayout.Controls.Add(textBoxName, 1, 1);
            infoLayout.Controls.Add(labelAge, 0, 2);
            infoLayout.Controls.Add(textBoxAge, 1, 2);
            infoLayout.Controls.Add(labelCourse, 0, 3);
            infoLayout.Controls.Add(textBoxCourse, 1, 3);

            // Add margin to labels and text boxes for spacing between rows
            foreach (Control control in infoLayout.Controls)
            {
                control.Margin = new Padding(5, 5, 5, 5);
            }

            // Customize buttons and add to FlowLayoutPanel with spacing
            CustomizeButton(buttonUpdate);
            CustomizeButton(buttonAdd);
            CustomizeButton(buttonGenerateReport);
            CustomizeButton(buttonDelete);

            FlowLayoutPanel buttonLayout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),
                Margin = new Padding(0)
            };
            buttonLayout.Controls.Add(buttonUpdate);
            buttonLayout.Controls.Add(buttonAdd);
            buttonLayout.Controls.Add(buttonGenerateReport);
            buttonLayout.Controls.Add(buttonDelete);

            // Add margin to each button for spacing
            foreach (Control button in buttonLayout.Controls)
            {
                button.Margin = new Padding(10, 0, 10, 0);
            }

            // Customize DataGridView
            CustomizeDataGridView();

            // Arrange everything in a FlowLayoutPanel for vertical stacking with padding
            FlowLayoutPanel mainFlowLayout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(20),
                Margin = new Padding(20)
            };

            mainFlowLayout.Controls.Add(labelTitle); // Add labelTitle at the top                                                     
            mainFlowLayout.Controls.Add(textBoxSearch);
            mainFlowLayout.Controls.Add(buttonSearch);
            mainFlowLayout.Controls.Add(labelStudentInfo);
            mainFlowLayout.Controls.Add(infoLayout);
            mainFlowLayout.Controls.Add(buttonLayout);
            mainFlowLayout.Controls.Add(labelStudentRecordsTable);
            mainFlowLayout.Controls.Add(dataGridViewStudents);
            mainFlowLayout.Controls.Add(labelSummary);
            mainFlowLayout.Controls.Add(labelTotalStudents);
            mainFlowLayout.Controls.Add(labelAverageAge);

            // Add mainFlowLayout to mainPanel
            mainPanel.Controls.Add(mainFlowLayout);

            // Button event handlers
            buttonAdd.Click += buttonAdd_Click;
            buttonUpdate.Click += buttonUpdate_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonGenerateReport.Click += buttonGenerateReport_Click;

            labelTitle.Margin = new Padding(110, 10, 120, 10);
            labelStudentInfo.Margin = new Padding(180, 10, 0, 30);
            labelStudentID.Margin = new Padding(10, 10, 0, 10);
            labelName.Margin = new Padding(10, 10, 0, 10);
            labelAge.Margin = new Padding(10, 10, 0, 10);
            labelCourse.Margin = new Padding(10, 10, 0, 10);
            labelTotalStudents.Margin = new Padding(30, 10, 0, 0);
            labelAverageAge.Margin = new Padding(30, 10, 0, 30);
            dataGridViewStudents.Margin = new Padding(90, 40, 0, 40);
        }

        private void CustomizeForm()
        {
            this.Text = "Student Management System";
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Size = new Size(800, 1000);
            this.Paint += new PaintEventHandler(FormPaint);
        }


        private void FormPaint(object sender, PaintEventArgs e)
        {
            int borderThickness = 20;
            Color borderColor = Color.LightSkyBlue;

            // Draw the border
            using (Pen borderPen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
        }

        private void CustomizeButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(50, 150, 250);
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            button.Height = 40;
            button.Width = 120;
            button.Padding = new Padding(5);

            // Hover effect
            button.MouseEnter += (sender, e) => button.BackColor = Color.FromArgb(30, 130, 230);
            button.MouseLeave += (sender, e) => button.BackColor = Color.FromArgb(50, 150, 250);
        }

        private void CustomizeDataGridView()
        {
            dataGridViewStudents.ColumnHeaderMouseClick += DataGridViewStudents_ColumnHeaderMouseClick;
            dataGridViewStudents.BackgroundColor = Color.White;
            dataGridViewStudents.BorderStyle = BorderStyle.None;
            dataGridViewStudents.GridColor = Color.Gainsboro;
            dataGridViewStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 255);
            dataGridViewStudents.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewStudents.EnableHeadersVisualStyles = false;
         

            // Adjust columns based on content size for better readability
            dataGridViewStudents.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the control at the clicked location
            Control clickedControl = this.GetChildAtPoint(e.Location);

            // If the clicked area is empty (no control), clear the student information
            if (clickedControl == null)
            {
                ClearStudentInformation();
            }
        }



        private void LoadStudents()
        {
            try
            {
                var students = dataHandler.GetAllStudents();
                dataGridViewStudents.DataSource = students;
                UpdateStudentStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentStatistics()
        {
            labelTotalStudents.Text = $"Total Students: {dataHandler.GetTotalStudents()}";
            labelAverageAge.Text = $"Average Age: {dataHandler.GetAverageAge():F2}";
        }

        private void CustomizeLabel(Label label, string text, Font font, Color color)
        {
            label.Text = text;
            label.Font = font;
            label.ForeColor = color;
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentID = textBoxStudentID.Text;
            if (string.IsNullOrWhiteSpace(studentID))
            {
                MessageBox.Show("Student ID cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxAge.Text) || !int.TryParse(textBoxAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age greater than 0.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCourse.Text))
            {
                MessageBox.Show("Course cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student newStudent = new Student(studentID, textBoxName.Text, age, textBoxCourse.Text);
            bool success = dataHandler.AddStudent(newStudent);
            if (success)
            {
                dataHandler.SaveStudentsToFile();
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents(); // Refresh the student list
            }
            else
            {
                MessageBox.Show("Error adding student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxStudentID.Text))
            {
                dataHandler.SaveStudentsToFile(); // Update Student.txt after updating in database
                MessageBox.Show("Student ID cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            string studentID = textBoxStudentID.Text;
            var student = dataHandler.GetAllStudents().Find(s => s.StudentID == studentID);
            if (student == null)
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            student.Name = textBoxName.Text;
            student.Age = int.TryParse(textBoxAge.Text, out int age) ? age : student.Age;
            student.Course = textBoxCourse.Text;

            dataHandler.UpdateStudent(student);
            LoadStudents(); // Refresh the student list
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string studentID = textBoxStudentID.Text;
            if (string.IsNullOrWhiteSpace(studentID))
            {
                MessageBox.Show("Please enter a valid Student ID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = dataHandler.DeleteStudent(studentID);
            if (success)
            {
                dataHandler.SaveStudentsToFile(); // Save data to text file after deleting
                MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents(); // Refresh the student list
            }
            else
            {
                MessageBox.Show("Error deleting student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataHandler.SaveStudentsToFile(); // Update Student.txt after updating in database

        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            // Generate the report summary data
            int totalStudents = dataHandler.GetTotalStudents();
            double averageAge = dataHandler.GetAverageAge();

            // Save the report summary to the database
            dataHandler.SaveReportSummary(totalStudents, averageAge);
            dataHandler.SaveReportSummaryToFile(); // Save data to text file

            // Open the ReportSummary form to display the summary
            var reportSummaryForm = new ReportSummary(dataHandler);
            reportSummaryForm.ShowDialog(); // Opens ReportSummary as a modal dialog

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Additional customization or logic during form load if needed
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text.ToLower().Trim();
            var allStudents = dataHandler.GetAllStudents(); // Get the complete list of students

            // If search term is empty or equals placeholder, show all students
            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm == placeholderText.ToLower())
            {
                dataGridViewStudents.DataSource = allStudents; // Reset to show all students
                return;
            }

            var filteredStudents = allStudents.Where(s =>
                s.StudentID.ToLower().Contains(searchTerm) || // Include Student ID in search
                s.Name.ToLower().Contains(searchTerm) ||
                s.Course.ToLower().Contains(searchTerm)
            ).ToList();

            dataGridViewStudents.DataSource = filteredStudents; // Update the DataGridView

            if (filteredStudents.Count == 0)
            {
                MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void DataGridViewStudents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridViewStudents.Columns[e.ColumnIndex].Name;
            if (dataGridViewStudents.DataSource is List<Student> students)
            {
                // Sort based on the selected column
                var sortedList = students.OrderBy(s => GetSortValue(s, columnName)).ToList();
                dataGridViewStudents.DataSource = sortedList;
            }
        }

        private object GetSortValue(Student student, string columnName)
        {
            if (columnName == "StudentID")
            {
                return student.StudentID;
            }
            else if (columnName == "Name")
            {
                return student.Name;
            }
            else if (columnName == "Age")
            {
                return student.Age;
            }
            else if (columnName == "Course")
            {
                return student.Course;
            }
            else
            {
                return student.StudentID; // Default sorting by StudentID
            }
        }

        // Method to set placeholder text
        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray; // Placeholder color

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black; // Reset color to normal
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray; // Placeholder color
                }
            };
        }

        private void DataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewStudents.SelectedRows[0];

                // Populate the text boxes with data from the selected row
                textBoxStudentID.Text = selectedRow.Cells["StudentID"].Value.ToString();
                textBoxName.Text = selectedRow.Cells["Name"].Value.ToString();
                textBoxAge.Text = selectedRow.Cells["Age"].Value.ToString();
                textBoxCourse.Text = selectedRow.Cells["Course"].Value.ToString();
            }
            else
            {
                // Clear the text boxes if no row is selected
                ClearStudentInformation();
            }
        }
        private void ClearStudentInformation()
        {
            textBoxStudentID.Clear();
            textBoxName.Clear();
            textBoxAge.Clear();
            textBoxCourse.Clear();
        }

    }
}
