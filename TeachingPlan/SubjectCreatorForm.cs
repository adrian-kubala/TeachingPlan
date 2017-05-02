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
            //DataTable table = new DataTable();

            //using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
            //{
            //    SqlCommand teachingPlanCommand = new SqlCommand("SELECT Nazwa_studiow as Studia FROM Studia;", connection);
            //    try
            //    {
            //        SqlDataAdapter dataAdapter = new SqlDataAdapter(teachingPlanCommand);

            //        table = new DataTable();
            //        dataAdapter.Fill(table);
            //    }
            //    catch (Exception exeption)
            //    {
            //        MessageBox.Show(exeption.Message);
            //    }
            //}

            //DataGridViewTextBoxColumn colum = new DataGridViewTextBoxColumn();
            //colum.Name = "Nazwa przedmiotu";
            //subjectsGridView.Columns.Add(colum);

            //DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            //comboBoxColumn.DataSource = table;
            //comboBoxColumn.DisplayMember = "Studia";
            //comboBoxColumn.Name = comboBoxColumn.DisplayMember.ToString();
            //subjectsGridView.Columns.Add(comboBoxColumn);
        }
    }
}
