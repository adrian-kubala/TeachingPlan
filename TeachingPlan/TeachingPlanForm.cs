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
                teachingPlanGridView.Dock = DockStyle.Fill;
                teachingPlanGridView.ReadOnly = true;
                teachingPlanGridView.AllowUserToAddRows = false;
                teachingPlanGridView.AllowUserToDeleteRows = false;
            }

            Text += accountType.ToString();
        }

        private void insertRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow lastRow = teachingPlanGridView.Rows[teachingPlanGridView.Rows.Count - 2];
                string subjectName = (string)lastRow.Cells[0].Value;
                int hours = (int)lastRow.Cells[8].Value;
                string classType = (string)lastRow.Cells[10].Value;
                int ects = (int)lastRow.Cells[11].Value;

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
