using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    string commandText = Properties.Resources.ResourceManager.GetString("Studia");

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
                    comboBoxColumn.DisplayMember = "Studia";
                }
            }
        }
    }
}
