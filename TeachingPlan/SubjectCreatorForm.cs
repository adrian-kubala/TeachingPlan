﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TeachingPlan
{
    public partial class SubjectCreatorForm : Form
    {
        private SqlExecutor sqlExecutor = new SqlExecutor();

        public MethodInvoker DidUpdateDatabase;

        public SubjectCreatorForm()
        {
            InitializeComponent();
        }

        private void SubjectCreatorForm_Load(object sender, EventArgs e)
        {
            foreach (var column in subjectsGridView.Columns)
            {
                if (column is DataGridViewComboBoxColumn)
                {
                    var comboBoxColumn = column as DataGridViewComboBoxColumn;
                    var columnHeader = comboBoxColumn.HeaderText;
                    string commandText = Properties.Resources.ResourceManager.GetString(columnHeader);
                    
                    comboBoxColumn.DataSource = sqlExecutor.Select(commandText);
                    comboBoxColumn.DisplayMember = columnHeader;
                }
            }
        }

        private void CloseFormEvent(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == "Zapisz")
            {
                foreach (DataGridViewRow row in subjectsGridView.Rows)
                {
                    if (row.Index == subjectsGridView.Rows.Count - 1)
                    {
                        MessageBox.Show("Aktualizacja bazy powiodła się!");
                        DidUpdateDatabase();
                        Close();

                        return;
                    }

                    sqlExecutor.InsertSubject(row);
                    sqlExecutor.AssignTeacher(row);
                    sqlExecutor.AssignSubject(row);
                }
            }
            else
            {
                var dialogResult = MessageBox.Show("Zmiany nie zostaną zapisane!", "Ostrzeżenie", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }
            }
        }

    }
}
