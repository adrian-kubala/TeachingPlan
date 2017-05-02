namespace TeachingPlan
{
    partial class SubjectCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.subjectsGridView = new System.Windows.Forms.DataGridView();
            this.subjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.studyMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.teacher = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.speciality = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.deanGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.hoursAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semesterNumber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.classesMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ectsPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectsGridView
            // 
            this.subjectsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.subjectsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectName,
            this.studyName,
            this.studyMode,
            this.teacher,
            this.speciality,
            this.deanGroup,
            this.hoursAmount,
            this.semesterNumber,
            this.classesMode,
            this.ectsPoints});
            this.subjectsGridView.Location = new System.Drawing.Point(30, 30);
            this.subjectsGridView.Name = "subjectsGridView";
            this.subjectsGridView.RowTemplate.Height = 33;
            this.subjectsGridView.Size = new System.Drawing.Size(2238, 724);
            this.subjectsGridView.TabIndex = 0;
            // 
            // subjectName
            // 
            this.subjectName.HeaderText = "Nazwa_przedmiotu";
            this.subjectName.Name = "subjectName";
            this.subjectName.Width = 240;
            // 
            // studyName
            // 
            this.studyName.HeaderText = "Studia";
            this.studyName.Name = "studyName";
            this.studyName.Width = 79;
            // 
            // studyMode
            // 
            this.studyMode.HeaderText = "Tryb_studiow";
            this.studyMode.Name = "studyMode";
            this.studyMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.studyMode.Width = 146;
            // 
            // teacher
            // 
            this.teacher.HeaderText = "Wykladowca";
            this.teacher.Name = "teacher";
            this.teacher.Width = 139;
            // 
            // speciality
            // 
            this.speciality.HeaderText = "Specjalnosc";
            this.speciality.Name = "speciality";
            this.speciality.Width = 135;
            // 
            // deanGroup
            // 
            this.deanGroup.HeaderText = "Grupa_dziekanska";
            this.deanGroup.Name = "deanGroup";
            this.deanGroup.Width = 198;
            // 
            // hoursAmount
            // 
            this.hoursAmount.HeaderText = "Ilosc_godzin";
            this.hoursAmount.Name = "hoursAmount";
            this.hoursAmount.Width = 177;
            // 
            // semesterNumber
            // 
            this.semesterNumber.HeaderText = "Numer_semestru";
            this.semesterNumber.Name = "semesterNumber";
            this.semesterNumber.Width = 181;
            // 
            // classesMode
            // 
            this.classesMode.HeaderText = "Tryb_zajec";
            this.classesMode.Name = "classesMode";
            this.classesMode.Width = 124;
            // 
            // ectsPoints
            // 
            this.ectsPoints.HeaderText = "Punkty_ECTS";
            this.ectsPoints.Name = "ectsPoints";
            this.ectsPoints.Width = 191;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exitButton.Location = new System.Drawing.Point(2133, 794);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(135, 61);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Wyjdź";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.CloseFormEvent);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(1976, 794);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(135, 61);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Zapisz";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.CloseFormEvent);
            // 
            // SubjectCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2312, 889);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.subjectsGridView);
            this.Name = "SubjectCreatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wprowadzanie przedmiotów";
            this.Load += new System.EventHandler(this.SubjectCreatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subjectsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView subjectsGridView;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectName;
        private System.Windows.Forms.DataGridViewComboBoxColumn studyName;
        private System.Windows.Forms.DataGridViewComboBoxColumn studyMode;
        private System.Windows.Forms.DataGridViewComboBoxColumn teacher;
        private System.Windows.Forms.DataGridViewComboBoxColumn speciality;
        private System.Windows.Forms.DataGridViewComboBoxColumn deanGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoursAmount;
        private System.Windows.Forms.DataGridViewComboBoxColumn semesterNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn classesMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ectsPoints;
    }
}