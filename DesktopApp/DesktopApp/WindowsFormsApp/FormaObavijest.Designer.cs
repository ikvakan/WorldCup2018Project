namespace WindowsFormsApp
{
    partial class FormaObavijest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaObavijest));
            this.lblNastavakInfo = new System.Windows.Forms.Label();
            this.btnDa = new System.Windows.Forms.Button();
            this.btnNE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNastavakInfo
            // 
            resources.ApplyResources(this.lblNastavakInfo, "lblNastavakInfo");
            this.lblNastavakInfo.Name = "lblNastavakInfo";
            // 
            // btnDa
            // 
            this.btnDa.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnDa, "btnDa");
            this.btnDa.Name = "btnDa";
            this.btnDa.UseVisualStyleBackColor = true;
            // 
            // btnNE
            // 
            this.btnNE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnNE, "btnNE");
            this.btnNE.Name = "btnNE";
            this.btnNE.UseVisualStyleBackColor = true;
            // 
            // FormaObavijest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNE);
            this.Controls.Add(this.btnDa);
            this.Controls.Add(this.lblNastavakInfo);
            this.Name = "FormaObavijest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNastavakInfo;
        private System.Windows.Forms.Button btnDa;
        private System.Windows.Forms.Button btnNE;
    }
}