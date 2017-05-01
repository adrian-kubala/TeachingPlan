using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingPlan
{
    public partial class TeachingPlanForm : Form
    {
        private AccountType accountType;
        private DataTable table;

        public TeachingPlanForm(AccountType type)
        {
            InitializeComponent();

            accountType = type;
            queryTypeComboBox.SelectedIndex = 0;
        }

        private void TeachingPlanForm_Load(object sender, EventArgs e)
        {
            String teachingPlanQueryText = Properties.Resources.plan_kształcenia;
            FillGridView(teachingPlanQueryText);

            UpdateText();

            if (accountType == AccountType.Student)
            {
                insertRowButton.Visible = false;
            }
            else
            {
                queryTypeComboBox.Items.Add("lista wykładowców grupy");
                queryTypeComboBox.Items.Add("ilość wykładowców grupy");
            }
        }

        private void FillGridView(string queryText)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
            {
                SqlCommand teachingPlanCommand = new SqlCommand(queryText, connection);
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(teachingPlanCommand);

                    table = new DataTable();
                    dataAdapter.Fill(table);

                    teachingPlanGridView.DataSource = table;
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message);
                }
            }
        }

        private void UpdateText()
        {
            Text += accountType.text();
        }

        private void insertRowButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow lastRow = teachingPlanGridView.Rows[teachingPlanGridView.Rows.Count - 2];
            SqlExecutor.Insert(table, lastRow);
        }

        private void queryTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string underscoredQueryTypeComboBoxText = (queryTypeComboBox.SelectedItem as string).Replace(" ", "_");
            FillGridView(Properties.Resources.ResourceManager.GetString(underscoredQueryTypeComboBoxText));

            int selectedIndex = queryTypeComboBox.SelectedIndex;
            insertRowButton.Enabled = selectedIndex == 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
