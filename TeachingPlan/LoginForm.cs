using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingPlan
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = accountTypeComboBox.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Nie wybrano żadnego konta");
                return;
            }

            TeachingPlanForm.AccountType type = (TeachingPlanForm.AccountType)Enum.ToObject(typeof(TeachingPlanForm.AccountType), selectedIndex);
            TeachingPlanForm form = new TeachingPlanForm(type);

            form.ShowDialog();
        }
    }
}
