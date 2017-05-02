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
        public static void Insert(DataTable table, DataGridViewRow row)
        {
            try
            {
                string subjectName = (string)row.Cells[0].Value;
                int hours = (int)row.Cells[8].Value;
                string classType = (string)row.Cells[10].Value;
                int ects = (int)row.Cells[11].Value;

                String insertSubjectQuery = Properties.Resources.DodajPrzedmiot;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
                {
                    SqlCommand insertSubjectCommand = new SqlCommand(insertSubjectQuery, connection);

                    int classTypeId = CheckForClassType(classType);
                    if (classTypeId < 0)
                    {
                        MessageBox.Show("Wprowadzono nieprawidłową wartosć w kolumnie Tryb_zajec");
                        return;
                    }

                    insertSubjectCommand.Parameters.Add(new SqlParameter("@nazwa", subjectName));
                    insertSubjectCommand.Parameters.Add(new SqlParameter("@id_rodzaj_zajec", classTypeId));
                    insertSubjectCommand.Parameters.Add(new SqlParameter("@ects", ects));
                    insertSubjectCommand.Parameters.Add(new SqlParameter("@godziny", hours));

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(insertSubjectCommand))
                    {
                        dataAdapter.InsertCommand = insertSubjectCommand;
                        dataAdapter.Update(table);

                        MessageBox.Show("Aktualizacja bazy powiodła się.");
                    }
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Pozostawiono puste pole(a). Aby dodać wpis uzupełnij dane.");
            }
        }

        private static int CheckForClassType(string classType)
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
