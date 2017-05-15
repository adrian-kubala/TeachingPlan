using System;
using System.Windows.Forms;

namespace TeachingPlan
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void InitComboBox()
        {
            accountTypeComboBox.SelectedIndex = 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = accountTypeComboBox.SelectedIndex;

            AccountType type = selectedIndex.AccountType();
            TeachingPlanForm form = new TeachingPlanForm(type);
            
            form.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
