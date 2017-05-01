namespace TeachingPlan
{
    partial class TeachingPlanForm
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
            this.teachingPlanGridView = new System.Windows.Forms.DataGridView();
            this.insertRowButton = new System.Windows.Forms.Button();
            this.queryTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.teachingPlanGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // teachingPlanGridView
            // 
            this.teachingPlanGridView.AllowUserToAddRows = false;
            this.teachingPlanGridView.AllowUserToDeleteRows = false;
            this.teachingPlanGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teachingPlanGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.teachingPlanGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachingPlanGridView.Location = new System.Drawing.Point(360, 34);
            this.teachingPlanGridView.Name = "teachingPlanGridView";
            this.teachingPlanGridView.ReadOnly = true;
            this.teachingPlanGridView.RowTemplate.Height = 33;
            this.teachingPlanGridView.Size = new System.Drawing.Size(2000, 926);
            this.teachingPlanGridView.TabIndex = 0;
            // 
            // insertRowButton
            // 
            this.insertRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.insertRowButton.Location = new System.Drawing.Point(12, 823);
            this.insertRowButton.Name = "insertRowButton";
            this.insertRowButton.Size = new System.Drawing.Size(331, 57);
            this.insertRowButton.TabIndex = 1;
            this.insertRowButton.Text = "Wprowadź przedmiot";
            this.insertRowButton.UseVisualStyleBackColor = true;
            this.insertRowButton.Click += new System.EventHandler(this.insertRowButton_Click);
            // 
            // queryTypeComboBox
            // 
            this.queryTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queryTypeComboBox.FormattingEnabled = true;
            this.queryTypeComboBox.Items.AddRange(new object[] {
            "plan kształcenia",
            "lista studentów grupy",
            "ilosć studentów w grupie",
            "wykładowcy katedr",
            "ilość wykładowców katedry"});
            this.queryTypeComboBox.Location = new System.Drawing.Point(12, 62);
            this.queryTypeComboBox.Name = "queryTypeComboBox";
            this.queryTypeComboBox.Size = new System.Drawing.Size(331, 33);
            this.queryTypeComboBox.TabIndex = 2;
            this.queryTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.queryTypeComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wyświetl dane:";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitButton.Location = new System.Drawing.Point(12, 903);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(331, 57);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Wyjdź";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // TeachingPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2388, 1001);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryTypeComboBox);
            this.Controls.Add(this.insertRowButton);
            this.Controls.Add(this.teachingPlanGridView);
            this.Name = "TeachingPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plany kształcenia - zalogowano jako ";
            this.Load += new System.EventHandler(this.TeachingPlanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teachingPlanGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView teachingPlanGridView;
        private System.Windows.Forms.Button insertRowButton;
        private System.Windows.Forms.ComboBox queryTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
    }
}