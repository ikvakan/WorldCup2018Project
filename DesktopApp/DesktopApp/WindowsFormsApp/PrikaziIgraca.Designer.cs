namespace WindowsFormsApp
{
    partial class PrikaziIgraca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrikaziIgraca));
            this.btnSpremi = new System.Windows.Forms.Button();
            this.btnUrediSliku = new System.Windows.Forms.Button();
            this.pictureBoxFavourite = new System.Windows.Forms.PictureBox();
            this.pictureBoxIgrac = new System.Windows.Forms.PictureBox();
            this.lblKapetan = new System.Windows.Forms.Label();
            this.lblOmiljeni = new System.Windows.Forms.Label();
            this.lblPozicija = new System.Windows.Forms.Label();
            this.lblBrojDresa = new System.Windows.Forms.Label();
            this.lblImeIgraca = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIgrac)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSpremi
            // 
            this.btnSpremi.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnSpremi, "btnSpremi");
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            // 
            // btnUrediSliku
            // 
            resources.ApplyResources(this.btnUrediSliku, "btnUrediSliku");
            this.btnUrediSliku.Name = "btnUrediSliku";
            this.btnUrediSliku.UseVisualStyleBackColor = true;
            this.btnUrediSliku.Click += new System.EventHandler(this.BtnUrediSliku_Click);
            // 
            // pictureBoxFavourite
            // 
            resources.ApplyResources(this.pictureBoxFavourite, "pictureBoxFavourite");
            this.pictureBoxFavourite.Name = "pictureBoxFavourite";
            this.pictureBoxFavourite.TabStop = false;
            // 
            // pictureBoxIgrac
            // 
            resources.ApplyResources(this.pictureBoxIgrac, "pictureBoxIgrac");
            this.pictureBoxIgrac.Name = "pictureBoxIgrac";
            this.pictureBoxIgrac.TabStop = false;
            // 
            // lblKapetan
            // 
            resources.ApplyResources(this.lblKapetan, "lblKapetan");
            this.lblKapetan.Name = "lblKapetan";
            // 
            // lblOmiljeni
            // 
            resources.ApplyResources(this.lblOmiljeni, "lblOmiljeni");
            this.lblOmiljeni.Name = "lblOmiljeni";
            // 
            // lblPozicija
            // 
            resources.ApplyResources(this.lblPozicija, "lblPozicija");
            this.lblPozicija.Name = "lblPozicija";
            // 
            // lblBrojDresa
            // 
            resources.ApplyResources(this.lblBrojDresa, "lblBrojDresa");
            this.lblBrojDresa.Name = "lblBrojDresa";
            // 
            // lblImeIgraca
            // 
            resources.ApplyResources(this.lblImeIgraca, "lblImeIgraca");
            this.lblImeIgraca.Name = "lblImeIgraca";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // PrikaziIgraca
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnUrediSliku);
            this.Controls.Add(this.pictureBoxFavourite);
            this.Controls.Add(this.pictureBoxIgrac);
            this.Controls.Add(this.lblKapetan);
            this.Controls.Add(this.lblOmiljeni);
            this.Controls.Add(this.lblPozicija);
            this.Controls.Add(this.lblBrojDresa);
            this.Controls.Add(this.lblImeIgraca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PrikaziIgraca";
            this.Load += new System.EventHandler(this.PrikaziIgraca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavourite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIgrac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Button btnUrediSliku;
        private System.Windows.Forms.PictureBox pictureBoxFavourite;
        private System.Windows.Forms.PictureBox pictureBoxIgrac;
        private System.Windows.Forms.Label lblKapetan;
        private System.Windows.Forms.Label lblOmiljeni;
        private System.Windows.Forms.Label lblPozicija;
        private System.Windows.Forms.Label lblBrojDresa;
        private System.Windows.Forms.Label lblImeIgraca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}