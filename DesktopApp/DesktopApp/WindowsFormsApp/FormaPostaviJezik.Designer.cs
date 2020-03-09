namespace WindowsFormsApp
{
    partial class FormaPostaviJezik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaPostaviJezik));
            this.label1 = new System.Windows.Forms.Label();
            this.btnHrvatski = new System.Windows.Forms.Button();
            this.btnEngleski = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnHrvatski
            // 
            this.btnHrvatski.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnHrvatski, "btnHrvatski");
            this.btnHrvatski.Name = "btnHrvatski";
            this.btnHrvatski.UseVisualStyleBackColor = true;
            this.btnHrvatski.Click += new System.EventHandler(this.BtnHrvatski_Click);
            // 
            // btnEngleski
            // 
            this.btnEngleski.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnEngleski, "btnEngleski");
            this.btnEngleski.Name = "btnEngleski";
            this.btnEngleski.UseVisualStyleBackColor = true;
            this.btnEngleski.Click += new System.EventHandler(this.BtnEngleski_Click);
            // 
            // FormaPostaviJezik
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEngleski);
            this.Controls.Add(this.btnHrvatski);
            this.Controls.Add(this.label1);
            this.Name = "FormaPostaviJezik";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHrvatski;
        private System.Windows.Forms.Button btnEngleski;
    }
}