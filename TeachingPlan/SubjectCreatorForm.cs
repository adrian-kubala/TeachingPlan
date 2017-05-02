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

                    DataTable table = new DataTable();

                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
                    {
                        SqlCommand command = new SqlCommand(commandText, connection);
                        try
                        {
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                            table = new DataTable();
                            dataAdapter.Fill(table);
                        }
                        catch (Exception exeption)
                        {
                            MessageBox.Show(exeption.Message);
                        }
                    }

                    comboBoxColumn.DataSource = table;
                    comboBoxColumn.DisplayMember = columnHeader;
                }
            }
        }

        private void CloseFormEvent(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == "Zapisz")
            {
                Close();
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
