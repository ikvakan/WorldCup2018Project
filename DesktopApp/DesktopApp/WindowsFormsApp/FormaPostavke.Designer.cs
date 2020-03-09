namespace WindowsFormsApp
{
    partial class FormaPostavke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaPostavke));
            this.lblPostavkeHInfo = new System.Windows.Forms.Label();
            this.btnPostavkeHDA = new System.Windows.Forms.Button();
            this.btnPostavkeHNE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPostavkeHInfo
            // 
            resources.ApplyResources(this.lblPostavkeHInfo, "lblPostavkeHInfo");
            this.lblPostavkeHInfo.Name = "lblPostavkeHInfo";
            // 
            // btnPostavkeHDA
            // 
            this.btnPostavkeHDA.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnPostavkeHDA, "btnPostavkeHDA");
            this.btnPostavkeHDA.Name = "btnPostavkeHDA";
            this.btnPostavkeHDA.UseVisualStyleBackColor = true;
            // 
            // btnPostavkeHNE
            // 
            this.btnPostavkeHNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnPostavkeHNE, "btnPostavkeHNE");
            this.btnPostavkeHNE.Name = "btnPostavkeHNE";
            this.btnPostavkeHNE.UseVisualStyleBackColor = true;
            // 
            // FormaPostavke
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPostavkeHNE);
            this.Controls.Add(this.btnPostavkeHDA);
            this.Controls.Add(this.lblPostavkeHInfo);
            this.Name = "FormaPostavke";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPostavkeHInfo;
        private System.Windows.Forms.Button btnPostavkeHDA;
        private System.Windows.Forms.Button btnPostavkeHNE;
    }
}