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
