using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRG272_GITHUB.DataAccess;

namespace PRG272_GITHUB
{
    static class Program
    {
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*
           Welcome to the Student Management System!
          Too run it in your own machine, please follow the steps below:

          1.Add your server name to the serverNames list below.
          2.Create the database "StudentManagement" in your SQL Server.
          3.Run the script in the "StudentManagement.sql" file to create the tables and the database.
          4.Run the application and enjoy!

           */

            List<string> serverNames = new List<string>
            {
                @"AKI\SQLEXPRESS", // guys this is my server name, please add/change your server name below
                @"SLY", // Moses
                @"salserver"  // Olifant
            };

            string databaseName = "StudentManagement";
            DataHandler dataHandler = null;

            foreach (var serverName in serverNames)
            {
                string connectionString = $@"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
                var handler = new DataHandler(connectionString);

                if (await Task.Run(() => handler.TestConnection()))
                {
                    dataHandler = handler;
                    MessageBox.Show($"Connected to server: {serverName}", "Connection Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }

            if (dataHandler == null)
            {
                MessageBox.Show("Unable to connect to any configured server. The application will now close.",
                                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit if all attempts fail
            }

            MainForm mainForm = new MainForm(dataHandler);

            try
            {
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




