using System;
using System.Data;
using System.Data.SqlClient;
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

            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.InsertCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataAdapter.Update(dataTable);
        }

        public int SelectTeacherIdBy(string lastName)
        {
            command = new SqlCommand(Properties.Resources.Id_nauczyciela_nazwisko, connection);
            command.Parameters.Add(new SqlParameter("@nazwisko", lastName));

            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.SelectCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable.Rows[0].Field<int>(0);
        }

        public void AssignTeacher(int teacherId, int subjectId)
        {
            command = new SqlCommand(Properties.Resources.insert_PRZEDMIOT_NAUCZYCIEL, connection);

            command.Parameters.Add(new SqlParameter("@Id_nauczyciela", teacherId));
            command.Parameters.Add(new SqlParameter("@Id_przedmiotu", subjectId));

            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.InsertCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataAdapter.Update(dataTable);
        }

        public int SelectSpecialityIdBy(string name)
        {
            command = new SqlCommand(Properties.Resources.Id_specjalnosci_nazwa, connection);
            command.Parameters.Add(new SqlParameter("@specjalnosc", name));

            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.SelectCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable.Rows[0].Field<int>(0);
        }

        public int SelectSubjectLastId()
        {
            var lastIdTable = Select(Properties.Resources.last_Id_przedmiotu);
            return lastIdTable.Rows[0].Field<int>(0);
        }

        public void AssignTeacher(DataGridViewRow row)
        {
            var comboBoxCell = row.Cells[3] as DataGridViewComboBoxCell;
            var lastName = comboBoxCell.Value as string;

            int teacherIdByLastName = SelectTeacherIdBy(lastName);
            int subjectLastId = SelectSubjectLastId();
            AssignTeacher(teacherIdByLastName, subjectLastId);
        }

        public void AssignSubject(DataGridViewRow row)
        {
            var comboBoxCell = row.Cells[4] as DataGridViewComboBoxCell;
            var specialityName = comboBoxCell.Value as string;

            int specialityIdByName = SelectSpecialityIdBy(specialityName);
            int subjectLastId = SelectSubjectLastId();

            command = new SqlCommand(Properties.Resources.insert_SPECJALNOSC_PRZEDMIOT, connection);

            command.Parameters.Add(new SqlParameter("@Id_specjalnosci", specialityIdByName));
            command.Parameters.Add(new SqlParameter("@Id_przedmiotu", subjectLastId));

            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.InsertCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataAdapter.Update(dataTable);
        }

        public DataTable Select(string commandText)
        {
            DataTable table = new DataTable();

            command = new SqlCommand(commandText, connection);
            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(table);

            return table;
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

    }
}
