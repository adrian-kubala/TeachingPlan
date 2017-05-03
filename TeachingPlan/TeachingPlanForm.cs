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
        
        public TeachingPlanForm(AccountType type)
        {
            InitializeComponent();

            accountType = type;
            queryTypeComboBox.SelectedIndex = 0;
        }

        private void TeachingPlanForm_Load(object sender, EventArgs e)
        {
            PrepareDataGridView();
            UpdateText();
            PrepareViewsForUser();
        }

        private void UpdateText()
        {
            Text += accountType.text();
        }

        private void PrepareViewsForUser()
        {
            if (accountType == AccountType.Student || accountType == AccountType.AdministrativeWorker)
            {
                insertRowButton.Visible = false;
            }

            if (accountType != AccountType.Student)
            {
                queryTypeComboBox.Items.Add("lista wykładowców grupy");
                queryTypeComboBox.Items.Add("ilość wykładowców grupy");
            }

            if (accountType != AccountType.Student && accountType != AccountType.Teacher)
            {
                queryTypeComboBox.Items.Add("lista katedr");
                insertRowButton.Text = "Przydziel prowadzącego";
            }

            if (accountType == AccountType.AdministrativeWorker)
            {
                queryTypeComboBox.Items.Add("obciążenie wykładowców");
            }
        }

        private void PrepareDataGridView()
        {
            String teachingPlanQueryText = Properties.Resources.plan_kształcenia;
            FillGridView(teachingPlanQueryText);
        }

        private void queryTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string underscoredQueryTypeComboBoxText = (queryTypeComboBox.SelectedItem as string).Replace(" ", "_");
            FillGridView(Properties.Resources.ResourceManager.GetString(underscoredQueryTypeComboBoxText));

            int selectedIndex = queryTypeComboBox.SelectedIndex;
            insertRowButton.Enabled = selectedIndex == 0;
        }

        private void FillGridView(string queryText)
        {
            teachingPlanGridView.DataSource = SqlExecutor.Select(queryText);
        }

        private void insertRowButton_Click(object sender, EventArgs e)
        {
            if (accountType == AccountType.Teacher)
            {
                SubjectCreatorForm form = new SubjectCreatorForm();
                form.invoker = new MethodInvoker(PrepareDataGridView);
                form.ShowDialog();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
