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
            ((System.ComponentModel.ISupportInitialize)(this.teachingPlanGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // teachingPlanGridView
            // 
            this.teachingPlanGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachingPlanGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.teachingPlanGridView.Location = new System.Drawing.Point(0, 0);
            this.teachingPlanGridView.Name = "teachingPlanGridView";
            this.teachingPlanGridView.RowTemplate.Height = 33;
            this.teachingPlanGridView.Size = new System.Drawing.Size(1696, 496);
            this.teachingPlanGridView.TabIndex = 0;
            // 
            // insertRowButton
            // 
            this.insertRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertRowButton.Location = new System.Drawing.Point(1431, 542);
            this.insertRowButton.Name = "insertRowButton";
            this.insertRowButton.Size = new System.Drawing.Size(253, 57);
            this.insertRowButton.TabIndex = 1;
            this.insertRowButton.Text = "Wprowadź wiersz";
            this.insertRowButton.UseVisualStyleBackColor = true;
            this.insertRowButton.Click += new System.EventHandler(this.insertRowButton_Click);
            // 
            // TeachingPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1696, 655);
            this.Controls.Add(this.insertRowButton);
            this.Controls.Add(this.teachingPlanGridView);
            this.Name = "TeachingPlanForm";
            this.Text = "Plany kształcenia - zalogowano jako ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TeachingPlanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teachingPlanGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView teachingPlanGridView;
        private System.Windows.Forms.Button insertRowButton;
    }
}