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
            String teachingPlanQueryText = Properties.Resources.Aplikacja_student_przegladanie;
            FillGridView(teachingPlanQueryText);

            UpdateText();

            if (accountType == AccountType.Student)
            {
                insertRowButton.Visible = false;
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
            int selectedIndex = queryTypeComboBox.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    FillGridView(Properties.Resources.Aplikacja_student_przegladanie);
                    break;
                case 1:
                    FillGridView(Properties.Resources.pierwsze_lista_studentow_grupy);
                    break;
                case 2:
                    FillGridView(Properties.Resources.pierwsze_ilosc_studentow_w_grupie);
                    break;
                case 3:
                    FillGridView(Properties.Resources.drugie_wykladowcy_katedr);
                    break;
                case 4:
                    FillGridView(Properties.Resources.drugie_ilosc_wykladowcow_katedry);
                    break;
            }

            insertRowButton.Enabled = selectedIndex == 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
