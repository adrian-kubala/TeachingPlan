using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TeachingPlan
{
    public partial class SubjectCreatorForm : Form
    {
        public SubjectCreatorForm()
        {
            InitializeComponent();
        }

        private void SubjectCreatorForm_Load(object sender, EventArgs e)
        {
            foreach (var column in subjectsGridView.Columns)
            {
                if (column is DataGridViewComboBoxColumn)
                {
                    var comboBoxColumn = column as DataGridViewComboBoxColumn;
                    var columnHeader = comboBoxColumn.HeaderText;
                    string commandText = Properties.Resources.ResourceManager.GetString(columnHeader);
                    
                    comboBoxColumn.DataSource = SqlExecutor.Select(commandText);
                    comboBoxColumn.DisplayMember = columnHeader;
                }
            }
        }

        private void CloseFormEvent(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == "Zapisz")
            {
                foreach (DataGridViewRow row in subjectsGridView.Rows)
                {
                    if (row.Index == subjectsGridView.Rows.Count - 1)
                    {
                        MessageBox.Show("Aktualizacja bazy powiodła się!");
                        Close();

                        return;
                    }

                    SqlExecutor.InsertSubject(row);

                    var lastIdTable = SqlExecutor.Select(Properties.Resources.last_Id_przedmiotu);
                    int subjectLastId = lastIdTable.Rows[0].Field<int>(0);

                    var comboBoxCell = row.Cells[3] as DataGridViewComboBoxCell;
                    var lastName = comboBoxCell.Value as string;

                    int teacherIdByLastName;

                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
                    {
                        SqlCommand teacherIdByLastNameCommand = new SqlCommand(Properties.Resources.Id_nauczyciela_nazwisko, connection);

                        teacherIdByLastNameCommand.Parameters.Add(new SqlParameter("@nazwisko", lastName));

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(teacherIdByLastNameCommand))
                        {
                            dataAdapter.SelectCommand = teacherIdByLastNameCommand;
                            var dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            teacherIdByLastName = dataTable.Rows[0].Field<int>(0);
                        }
                    }


                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
                    {
                        SqlCommand assignTeacherCommand = new SqlCommand(Properties.Resources.insert_PRZEDMIOT_NAUCZYCIEL, connection);

                        assignTeacherCommand.Parameters.Add(new SqlParameter("@Id_przedmiotu", subjectLastId));
                        assignTeacherCommand.Parameters.Add(new SqlParameter("@Id_nauczyciela", teacherIdByLastName));

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(assignTeacherCommand))
                        {
                            dataAdapter.InsertCommand = assignTeacherCommand;
                            var dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataAdapter.Update(dataTable);
                        }
                    }

                }
            }
            else
            {
                var dialogResult = MessageBox.Show("Zmiany nie zostaną zapisane!", "Ostrzeżenie", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }
            }
        }

    }
}
