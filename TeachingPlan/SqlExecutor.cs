using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingPlan
{
    class SqlExecutor
    {
        public static void InsertSubject(DataGridViewRow row)
        {
            var comboBoxCell = row.Cells[8] as DataGridViewComboBoxCell;
            var classTypeId = SqlExecutor.CheckForClassType(comboBoxCell.Value as string);

            var textBoxCell = row.Cells[0] as DataGridViewTextBoxCell;
            var subjectName = textBoxCell.Value as string;

            textBoxCell = row.Cells[9] as DataGridViewTextBoxCell;
            var ects = textBoxCell.Value as string;

            textBoxCell = row.Cells[6] as DataGridViewTextBoxCell;
            var hours = textBoxCell.Value as string;

            String insertSubjectQuery = Properties.Resources.insert_Przedmiot;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
            {
                SqlCommand insertSubjectCommand = new SqlCommand(insertSubjectQuery, connection);

                insertSubjectCommand.Parameters.Add(new SqlParameter("@nazwa", subjectName));
                insertSubjectCommand.Parameters.Add(new SqlParameter("@id_rodzaj_zajec", classTypeId));
                insertSubjectCommand.Parameters.Add(new SqlParameter("@ects", ects));
                insertSubjectCommand.Parameters.Add(new SqlParameter("@godziny", hours));

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(insertSubjectCommand))
                {
                    dataAdapter.InsertCommand = insertSubjectCommand;
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Update(dataTable);
                }
            }
        }

        public static int CheckForClassType(string classType)
        {
            switch (classType)
            {
                case "Wyklad":
                    return 1;
                case "Cwiczenia":
                    return 2;
                case "Laboratoria":
                    return 3;
                case "Projekt":
                    return 4;
                default:
                    return -1;
            }
        }

        public static DataTable Select(string commandText)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(table);
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message);
                }
            }

            return table;
        }

    }
}
