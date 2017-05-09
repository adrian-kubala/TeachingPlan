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
        private SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString);
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;

        public void InsertSubject(DataGridViewRow row)
        {
            var comboBoxCell = row.Cells[8] as DataGridViewComboBoxCell;
            var classTypeId = CheckForClassType(comboBoxCell.Value as string);

            var textBoxCell = row.Cells[0] as DataGridViewTextBoxCell;
            var subjectName = textBoxCell.Value as string;

            textBoxCell = row.Cells[9] as DataGridViewTextBoxCell;
            var ects = textBoxCell.Value as string;

            textBoxCell = row.Cells[6] as DataGridViewTextBoxCell;
            var hours = textBoxCell.Value as string;

            String insertSubjectQuery = Properties.Resources.insert_Przedmiot;

            command = new SqlCommand(insertSubjectQuery, connection);

            command.Parameters.Add(new SqlParameter("@nazwa", subjectName));
            command.Parameters.Add(new SqlParameter("@id_rodzaj_zajec", classTypeId));
            command.Parameters.Add(new SqlParameter("@ects", ects));
            command.Parameters.Add(new SqlParameter("@godziny", hours));

            using (dataAdapter = new SqlDataAdapter(command))
            {
                dataAdapter.InsertCommand = command;
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataAdapter.Update(dataTable);
            }
        }

        private int CheckForClassType(string classType)
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

        public DataTable Select(string commandText)
        {
            DataTable table = new DataTable();

            command = new SqlCommand(commandText, connection);
            using (dataAdapter = new SqlDataAdapter(command))
            {
                dataAdapter.Fill(table);
            }

            return table;
        }

    }
}
