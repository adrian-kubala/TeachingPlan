﻿using System;
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

                    DataTable table = new DataTable();
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

    }
}
