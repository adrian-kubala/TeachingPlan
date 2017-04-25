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

                    insertSubjectCommand.Parameters.Add(new SqlParameter("@nazwa", subjectName));
                    insertSubjectCommand.Parameters.Add(new SqlParameter("@id_rodzaj_zajec", 1));
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

    }
}
