using PRG272_GITHUB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG272_GITHUB.DataAccess
{
    public class DataHandler
    {
        private readonly string _connectionString;
        public DataHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connection succeeded!", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool AddStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Students (StudentID, Name, Age, Course) VALUES (@StudentID, @Name, @Age, @Course)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar).Value = student.StudentID; // Changed to NVarChar
                    cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = student.Name;
                    cmd.Parameters.Add("@Age", System.Data.SqlDbType.Int).Value = student.Age;
                    cmd.Parameters.Add("@Course", System.Data.SqlDbType.NVarChar).Value = student.Course;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error adding student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT StudentID, Name, Age, Course FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = reader.GetString(0), // Changed to string
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Course = reader.GetString(3)
                            });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error retrieving students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return students;
        }
        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Students SET Name = @Name, Age = @Age, Course = @Course WHERE StudentID = @StudentID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = student.Name;
                    cmd.Parameters.Add("@Age", System.Data.SqlDbType.Int).Value = student.Age;
                    cmd.Parameters.Add("@Course", System.Data.SqlDbType.NVarChar).Value = student.Course;
                    cmd.Parameters.Add("@StudentID", System.Data.SqlDbType.NVarChar).Value = student.StudentID; // Changed to NVarChar

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Display whether any rows were updated
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No student found with the specified Student ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error updating student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public double GetAverageAge()
        {
            double averageAge = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT AVG(Age) FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        averageAge = Convert.ToDouble(result);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error retrieving average age: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return averageAge;
        }
        public int GetTotalStudents()
        {
            int totalStudents = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    totalStudents = (int)cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error retrieving total students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return totalStudents;
        }

        public bool DeleteReport(int reportID)
        {
            try
            {
                // Assuming you're using a SQL database, replace with your actual database logic
                string query = "DELETE FROM ReportSummary WHERE ReportID = @ReportID";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReportID", reportID);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log error, etc.)
                Console.WriteLine($"Error deleting report: {ex.Message}");
                return false;
            }
        }
        public bool DeleteStudent(string studentID) // Changed to string
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID); // Changed to string

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error deleting student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public void SaveReportSummary(int totalStudents, double averageAge)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO ReportSummary (TotalStudents, AverageAge) VALUES (@TotalStudents, @AverageAge)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TotalStudents", totalStudents);
                command.Parameters.AddWithValue("@AverageAge", averageAge);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public DataTable GetReportSummaryData()
        {
            DataTable reportSummaryTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Ensure column names match those in the database exactly
                string query = "SELECT ReportID, TotalStudents, AverageAge, ReportDate FROM ReportSummary";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reportSummaryTable.Load(reader);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error retrieving report summary data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return reportSummaryTable;
        }

        // Very important you have to change it to your text file path
        public void SaveStudentsToFile()
        {
            // Navigate up two levels from bin\Debug or bin\Release to solution root, then to Text files
            string solutionDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(solutionDir, "Text files", "Student.txt");
            var students = GetAllStudents();

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.StudentID},{student.Name},{student.Age},{student.Course}");
                }
            }
        }

        public void SaveReportSummaryToFile()
        {
            // Navigate up two levels from bin\Debug or bin\Release to solution root, then to Text files
            string solutionDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(solutionDir, "Text files", "ReportSummary.txt");

            // Check if the file exists, and create it if it doesn’t
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose(); // Create and close the file
            }

            DataTable reportData = GetReportSummaryData();

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (DataRow row in reportData.Rows)
                {
                    writer.WriteLine($"{row["ReportID"]},{row["TotalStudents"]},{row["AverageAge"]},{row["ReportDate"]}");
                }
            }
        }










    }
}
