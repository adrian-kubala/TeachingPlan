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
            accountTypeComboBox.SelectedIndex = 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = accountTypeComboBox.SelectedIndex;

            AccountType type = (AccountType)Enum.ToObject(typeof(AccountType), selectedIndex);
            TeachingPlanForm form = new TeachingPlanForm(type);
            
            form.ShowDialog();
        }
    }
}
