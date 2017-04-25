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
            // TeachingPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1696, 655);
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
    }
}