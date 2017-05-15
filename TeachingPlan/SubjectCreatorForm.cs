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
                    AssignTeacherFromRow(row);

                    var comboBoxCell = row.Cells[4] as DataGridViewComboBoxCell;
                    var specialityName = comboBoxCell.Value as string;

                    int specialityIdByName = sqlExecutor.SelectSpecialityIdBy(specialityName);
                    int subjectLastId = sqlExecutor.SelectSubjectLastId();

                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.teachingPlanConnectionString))
                    {
                        SqlCommand assignSubject = new SqlCommand(Properties.Resources.insert_SPECJALNOSC_PRZEDMIOT, connection);

                        assignSubject.Parameters.Add(new SqlParameter("@Id_specjalnosci", specialityIdByName));
                        assignSubject.Parameters.Add(new SqlParameter("@Id_przedmiotu", subjectLastId));

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(assignSubject))
                        {
                            dataAdapter.InsertCommand = assignSubject;
                            var dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataAdapter.Update(dataTable);
                        }
                    }

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

        private void AssignTeacherFromRow(DataGridViewRow row)
        {
            var comboBoxCell = row.Cells[3] as DataGridViewComboBoxCell;
            var lastName = comboBoxCell.Value as string;

            int teacherIdByLastName = sqlExecutor.SelectTeacherIdBy(lastName);
            int subjectLastId = sqlExecutor.SelectSubjectLastId();
            sqlExecutor.AssignTeacher(teacherIdByLastName, subjectLastId);
        }



    }
}
