namespace WindowsFormsApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ispisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postavkeStraniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odabirPrinteraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledPrijeIspisaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ispisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postaviJezikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hrvatskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.engleskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOdabrani = new System.Windows.Forms.Label();
            this.flpOmiljeniIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOdaberiReprezentaciju = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIgraci = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajUOmiljeneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DodajIgracaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOdaberi = new System.Windows.Forms.Button();
            this.cbReprezentacijie = new System.Windows.Forms.ComboBox();
            this.contextMenuStripOdabrani = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prikaziIgračaToolStripMenuPrikaziIgraca = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemObrisiIgraca = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuObrisiSve = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSortYellowCards = new System.Windows.Forms.Button();
            this.btnSortdGoalsScored = new System.Windows.Forms.Button();
            this.btnSortedAttendance = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.contextMenuStripOdabrani.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.ispisToolStripMenuItem,
            this.postavkeToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            resources.ApplyResources(this.openFileToolStripMenuItem, "openFileToolStripMenuItem");
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            resources.ApplyResources(this.saveFileToolStripMenuItem, "saveFileToolStripMenuItem");
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // ispisToolStripMenuItem
            // 
            this.ispisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeStraniceToolStripMenuItem,
            this.odabirPrinteraToolStripMenuItem,
            this.pregledPrijeIspisaToolStripMenuItem,
            this.ispisToolStripMenuItem1});
            this.ispisToolStripMenuItem.Name = "ispisToolStripMenuItem";
            resources.ApplyResources(this.ispisToolStripMenuItem, "ispisToolStripMenuItem");
            // 
            // postavkeStraniceToolStripMenuItem
            // 
            this.postavkeStraniceToolStripMenuItem.Name = "postavkeStraniceToolStripMenuItem";
            resources.ApplyResources(this.postavkeStraniceToolStripMenuItem, "postavkeStraniceToolStripMenuItem");
            this.postavkeStraniceToolStripMenuItem.Click += new System.EventHandler(this.PostavkeStraniceToolStripMenuItem_Click);
            // 
            // odabirPrinteraToolStripMenuItem
            // 
            this.odabirPrinteraToolStripMenuItem.Name = "odabirPrinteraToolStripMenuItem";
            resources.ApplyResources(this.odabirPrinteraToolStripMenuItem, "odabirPrinteraToolStripMenuItem");
            this.odabirPrinteraToolStripMenuItem.Click += new System.EventHandler(this.OdabirPrinteraToolStripMenuItem_Click);
            // 
            // pregledPrijeIspisaToolStripMenuItem
            // 
            this.pregledPrijeIspisaToolStripMenuItem.Name = "pregledPrijeIspisaToolStripMenuItem";
            resources.ApplyResources(this.pregledPrijeIspisaToolStripMenuItem, "pregledPrijeIspisaToolStripMenuItem");
            this.pregledPrijeIspisaToolStripMenuItem.Click += new System.EventHandler(this.PregledPrijeIspisaToolStripMenuItem_Click);
            // 
            // ispisToolStripMenuItem1
            // 
            this.ispisToolStripMenuItem1.Name = "ispisToolStripMenuItem1";
            resources.ApplyResources(this.ispisToolStripMenuItem1, "ispisToolStripMenuItem1");
            this.ispisToolStripMenuItem1.Click += new System.EventHandler(this.IspisToolStripMenuItem1_Click);
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postaviJezikToolStripMenuItem});
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            resources.ApplyResources(this.postavkeToolStripMenuItem, "postavkeToolStripMenuItem");
            // 
            // postaviJezikToolStripMenuItem
            // 
            this.postaviJezikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hrvatskiToolStripMenuItem,
            this.engleskiToolStripMenuItem});
            this.postaviJezikToolStripMenuItem.Name = "postaviJezikToolStripMenuItem";
            resources.ApplyResources(this.postaviJezikToolStripMenuItem, "postaviJezikToolStripMenuItem");
            // 
            // hrvatskiToolStripMenuItem
            // 
            this.hrvatskiToolStripMenuItem.Name = "hrvatskiToolStripMenuItem";
            resources.ApplyResources(this.hrvatskiToolStripMenuItem, "hrvatskiToolStripMenuItem");
            this.hrvatskiToolStripMenuItem.Click += new System.EventHandler(this.HrvatskiToolStripMenuItem_Click);
            // 
            // engleskiToolStripMenuItem
            // 
            this.engleskiToolStripMenuItem.Name = "engleskiToolStripMenuItem";
            resources.ApplyResources(this.engleskiToolStripMenuItem, "engleskiToolStripMenuItem");
            this.engleskiToolStripMenuItem.Click += new System.EventHandler(this.EngleskiToolStripMenuItem_Click);
            // 
            // labelOdabrani
            // 
            resources.ApplyResources(this.labelOdabrani, "labelOdabrani");
            this.labelOdabrani.Name = "labelOdabrani";
            // 
            // flpOmiljeniIgraci
            // 
            this.flpOmiljeniIgraci.AllowDrop = true;
            resources.ApplyResources(this.flpOmiljeniIgraci, "flpOmiljeniIgraci");
            this.flpOmiljeniIgraci.BackColor = System.Drawing.SystemColors.Window;
            this.flpOmiljeniIgraci.Name = "flpOmiljeniIgraci";
            this.flpOmiljeniIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.FlpOmiljeniIgraci_DragDrop);
            this.flpOmiljeniIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.FlpOmiljeniIgraci_DragEnter);
            // 
            // lblOdaberiReprezentaciju
            // 
            resources.ApplyResources(this.lblOdaberiReprezentaciju, "lblOdaberiReprezentaciju");
            this.lblOdaberiReprezentaciju.Name = "lblOdaberiReprezentaciju";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbIgraci
            // 
            this.lbIgraci.AllowDrop = true;
            this.lbIgraci.ContextMenuStrip = this.contextMenuStrip;
            this.lbIgraci.FormattingEnabled = true;
            resources.ApplyResources(this.lbIgraci, "lbIgraci");
            this.lbIgraci.Name = "lbIgraci";
            this.lbIgraci.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbIgraci.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbIgraci_MouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.AllowDrop = true;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajUOmiljeneToolStripMenuItem,
            this.DodajIgracaToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // dodajUOmiljeneToolStripMenuItem
            // 
            this.dodajUOmiljeneToolStripMenuItem.Name = "dodajUOmiljeneToolStripMenuItem";
            resources.ApplyResources(this.dodajUOmiljeneToolStripMenuItem, "dodajUOmiljeneToolStripMenuItem");
            this.dodajUOmiljeneToolStripMenuItem.Click += new System.EventHandler(this.DodajUOmiljeneToolStripMenuItem_Click);
            // 
            // DodajIgracaToolStripMenuItem
            // 
            this.DodajIgracaToolStripMenuItem.Name = "DodajIgracaToolStripMenuItem";
            resources.ApplyResources(this.DodajIgracaToolStripMenuItem, "DodajIgracaToolStripMenuItem");
            this.DodajIgracaToolStripMenuItem.Click += new System.EventHandler(this.DodajIgracaToolStripMenuItem_Click);
            // 
            // btnOdaberi
            // 
            resources.ApplyResources(this.btnOdaberi, "btnOdaberi");
            this.btnOdaberi.Name = "btnOdaberi";
            this.btnOdaberi.UseVisualStyleBackColor = true;
            this.btnOdaberi.Click += new System.EventHandler(this.BtnOdaberi_Click);
            // 
            // cbReprezentacijie
            // 
            this.cbReprezentacijie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReprezentacijie.FormattingEnabled = true;
            resources.ApplyResources(this.cbReprezentacijie, "cbReprezentacijie");
            this.cbReprezentacijie.Name = "cbReprezentacijie";
            // 
            // contextMenuStripOdabrani
            // 
            this.contextMenuStripOdabrani.AllowDrop = true;
            this.contextMenuStripOdabrani.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prikaziIgračaToolStripMenuPrikaziIgraca,
            this.toolStripMenuItemObrisiIgraca,
            this.toolStripMenuObrisiSve});
            this.contextMenuStripOdabrani.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStripOdabrani, "contextMenuStripOdabrani");
            this.contextMenuStripOdabrani.Opened += new System.EventHandler(this.ContextMenuStripOdabrani_Opened);
            // 
            // prikaziIgračaToolStripMenuPrikaziIgraca
            // 
            this.prikaziIgračaToolStripMenuPrikaziIgraca.Name = "prikaziIgračaToolStripMenuPrikaziIgraca";
            resources.ApplyResources(this.prikaziIgračaToolStripMenuPrikaziIgraca, "prikaziIgračaToolStripMenuPrikaziIgraca");
            this.prikaziIgračaToolStripMenuPrikaziIgraca.Click += new System.EventHandler(this.PrikaziIgračaToolStripMenuPrikaziIgraca_Click);
            // 
            // toolStripMenuItemObrisiIgraca
            // 
            this.toolStripMenuItemObrisiIgraca.Name = "toolStripMenuItemObrisiIgraca";
            resources.ApplyResources(this.toolStripMenuItemObrisiIgraca, "toolStripMenuItemObrisiIgraca");
            this.toolStripMenuItemObrisiIgraca.Click += new System.EventHandler(this.ToolStripMenuItemObrisiIgraca_Click);
            // 
            // toolStripMenuObrisiSve
            // 
            this.toolStripMenuObrisiSve.Name = "toolStripMenuObrisiSve";
            resources.ApplyResources(this.toolStripMenuObrisiSve, "toolStripMenuObrisiSve");
            this.toolStripMenuObrisiSve.Click += new System.EventHandler(this.ToolStripMenuObrisiSve_Click);
            // 
            // btnSortYellowCards
            // 
            resources.ApplyResources(this.btnSortYellowCards, "btnSortYellowCards");
            this.btnSortYellowCards.Name = "btnSortYellowCards";
            this.btnSortYellowCards.UseVisualStyleBackColor = true;
            this.btnSortYellowCards.Click += new System.EventHandler(this.BtnSortYellowCards_Click);
            // 
            // btnSortdGoalsScored
            // 
            resources.ApplyResources(this.btnSortdGoalsScored, "btnSortdGoalsScored");
            this.btnSortdGoalsScored.Name = "btnSortdGoalsScored";
            this.btnSortdGoalsScored.UseVisualStyleBackColor = true;
            this.btnSortdGoalsScored.Click += new System.EventHandler(this.BtnSortdGoalsScored_Click);
            // 
            // btnSortedAttendance
            // 
            resources.ApplyResources(this.btnSortedAttendance, "btnSortedAttendance");
            this.btnSortedAttendance.Name = "btnSortedAttendance";
            this.btnSortedAttendance.UseVisualStyleBackColor = true;
            this.btnSortedAttendance.Click += new System.EventHandler(this.BtnSortedAttendance_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSortedAttendance);
            this.Controls.Add(this.btnSortdGoalsScored);
            this.Controls.Add(this.btnSortYellowCards);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.labelOdabrani);
            this.Controls.Add(this.flpOmiljeniIgraci);
            this.Controls.Add(this.lblOdaberiReprezentaciju);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbIgraci);
            this.Controls.Add(this.btnOdaberi);
            this.Controls.Add(this.cbReprezentacijie);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStripOdabrani.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.Label labelOdabrani;
        private System.Windows.Forms.FlowLayoutPanel flpOmiljeniIgraci;
        private System.Windows.Forms.Label lblOdaberiReprezentaciju;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbIgraci;
        private System.Windows.Forms.Button btnOdaberi;
        private System.Windows.Forms.ComboBox cbReprezentacijie;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOdabrani;
        private System.Windows.Forms.ToolStripMenuItem prikaziIgračaToolStripMenuPrikaziIgraca;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemObrisiIgraca;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuObrisiSve;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem dodajUOmiljeneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DodajIgracaToolStripMenuItem;
        private System.Windows.Forms.Button btnSortYellowCards;
        private System.Windows.Forms.Button btnSortdGoalsScored;
        private System.Windows.Forms.Button btnSortedAttendance;
        private System.Windows.Forms.ToolStripMenuItem ispisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postavkeStraniceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odabirPrinteraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledPrijeIspisaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ispisToolStripMenuItem1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postaviJezikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hrvatskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem engleskiToolStripMenuItem;
    }
}

