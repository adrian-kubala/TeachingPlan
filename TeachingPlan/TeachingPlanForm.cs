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
        }

        private void TeachingPlanForm_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void FillGridView()
        {
            String teachingPlanQueryText = Properties.Resources.Aplikacja_student_przegladanie;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
            {
                SqlCommand teachingPlanCommand = new SqlCommand(teachingPlanQueryText, connection);
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

            if (accountType == AccountType.Student)
            {
                teachingPlanGridView.ReadOnly = true;
                teachingPlanGridView.AllowUserToAddRows = false;
                teachingPlanGridView.AllowUserToDeleteRows = false;
                insertRowButton.Visible = false;
            }

            UpdateText();
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
