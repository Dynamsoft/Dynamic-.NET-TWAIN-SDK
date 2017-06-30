namespace Annotation_Samples
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnLannotation = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEannotation = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRannotation = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnTannotation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripFill = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBtnFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripPen = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBtnPen = new System.Windows.Forms.ToolStripButton();
            this.toolStripCbxPen = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripFont = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBtnFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripCbxFont = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnBringToBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnBringToFront = new System.Windows.Forms.ToolStripButton();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dsViewer1 = new Dynamsoft.Forms.DSViewer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.annotationToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(714, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.printToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "&Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAllToolStripMenuItem.Text = "&Save All...";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeToolStripMenuItem.Text = "&Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // annotationToolStripMenuItem
            // 
            this.annotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.delToolStripMenuItem,
            this.deleteAllToolStripMenuItem,
            this.copySelectedToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.annotationToolStripMenuItem.Name = "annotationToolStripMenuItem";
            this.annotationToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.annotationToolStripMenuItem.Text = "&Annotation";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.textToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.createToolStripMenuItem.Text = "&Create";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.lineToolStripMenuItem.Text = "&Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ellipseToolStripMenuItem.Text = "&Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem.Text = "&Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.textToolStripMenuItem.Text = "&Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.delToolStripMenuItem.Text = "&Delete Selected";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.toolStripBtnDelete_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteAllToolStripMenuItem.Text = "Delete &All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.toolStripBtnDeleteAll_Click);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.copySelectedToolStripMenuItem.Text = "C&opy Selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.copySelectedToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnLannotation,
            this.toolStripBtnEannotation,
            this.toolStripBtnRannotation,
            this.toolStripBtnTannotation,
            this.toolStripSeparator1,
            this.toolStripFill,
            this.toolStripBtnFill,
            this.toolStripPen,
            this.toolStripBtnPen,
            this.toolStripCbxPen,
            this.toolStripFont,
            this.toolStripBtnFont,
            this.toolStripCbxFont,
            this.toolStripSeparator2,
            this.toolStripBtnDelete,
            this.toolStripBtnDeleteAll,
            this.toolStripSeparator3,
            this.toolStripBtnBringToBack,
            this.toolStripBtnBringToFront});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(714, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripBtnLannotation
            // 
            this.toolStripBtnLannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnLannotation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnLannotation.Image")));
            this.toolStripBtnLannotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnLannotation.Name = "toolStripBtnLannotation";
            this.toolStripBtnLannotation.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnLannotation.Text = "toolStripButton1";
            this.toolStripBtnLannotation.ToolTipText = "Line";
            this.toolStripBtnLannotation.Click += new System.EventHandler(this.toolStripBtnLannotation_Click);
            // 
            // toolStripBtnEannotation
            // 
            this.toolStripBtnEannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEannotation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEannotation.Image")));
            this.toolStripBtnEannotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEannotation.Name = "toolStripBtnEannotation";
            this.toolStripBtnEannotation.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnEannotation.Text = "toolStripButton2";
            this.toolStripBtnEannotation.ToolTipText = "Ellipse";
            this.toolStripBtnEannotation.Click += new System.EventHandler(this.toolStripBtnEannotation_Click);
            // 
            // toolStripBtnRannotation
            // 
            this.toolStripBtnRannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRannotation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRannotation.Image")));
            this.toolStripBtnRannotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRannotation.Name = "toolStripBtnRannotation";
            this.toolStripBtnRannotation.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnRannotation.Text = "toolStripButton3";
            this.toolStripBtnRannotation.ToolTipText = "Rectangle";
            this.toolStripBtnRannotation.Click += new System.EventHandler(this.toolStripBtnRannotation_Click);
            // 
            // toolStripBtnTannotation
            // 
            this.toolStripBtnTannotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnTannotation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnTannotation.Image")));
            this.toolStripBtnTannotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnTannotation.Name = "toolStripBtnTannotation";
            this.toolStripBtnTannotation.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnTannotation.Text = "toolStripButton4";
            this.toolStripBtnTannotation.ToolTipText = "Text";
            this.toolStripBtnTannotation.Click += new System.EventHandler(this.toolStripBtnTannotation_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripFill
            // 
            this.toolStripFill.Name = "toolStripFill";
            this.toolStripFill.Size = new System.Drawing.Size(22, 22);
            this.toolStripFill.Text = "Fill";
            // 
            // toolStripBtnFill
            // 
            this.toolStripBtnFill.AutoSize = false;
            this.toolStripBtnFill.BackColor = System.Drawing.Color.Yellow;
            this.toolStripBtnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFill.Name = "toolStripBtnFill";
            this.toolStripBtnFill.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnFill.Text = "toolStripButton1";
            this.toolStripBtnFill.ToolTipText = "Fill Color";
            this.toolStripBtnFill.Click += new System.EventHandler(this.toolStripBtnFill_Click);
            // 
            // toolStripPen
            // 
            this.toolStripPen.Name = "toolStripPen";
            this.toolStripPen.Size = new System.Drawing.Size(27, 22);
            this.toolStripPen.Text = "Pen";
            // 
            // toolStripBtnPen
            // 
            this.toolStripBtnPen.BackColor = System.Drawing.Color.Blue;
            this.toolStripBtnPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPen.Name = "toolStripBtnPen";
            this.toolStripBtnPen.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnPen.Text = "toolStripButton1";
            this.toolStripBtnPen.ToolTipText = "Pen Color";
            this.toolStripBtnPen.Click += new System.EventHandler(this.toolStripBtnPen_Click);
            // 
            // toolStripCbxPen
            // 
            this.toolStripCbxPen.AutoSize = false;
            this.toolStripCbxPen.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.toolStripCbxPen.Name = "toolStripCbxPen";
            this.toolStripCbxPen.Size = new System.Drawing.Size(60, 23);
            this.toolStripCbxPen.ToolTipText = "Pen Width";
            // 
            // toolStripFont
            // 
            this.toolStripFont.Name = "toolStripFont";
            this.toolStripFont.Size = new System.Drawing.Size(31, 22);
            this.toolStripFont.Text = "Font";
            // 
            // toolStripBtnFont
            // 
            this.toolStripBtnFont.BackColor = System.Drawing.Color.Black;
            this.toolStripBtnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFont.Name = "toolStripBtnFont";
            this.toolStripBtnFont.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnFont.Text = "toolStripButton1";
            this.toolStripBtnFont.ToolTipText = "Font Color";
            this.toolStripBtnFont.Click += new System.EventHandler(this.toolStripBtnFont_Click);
            // 
            // toolStripCbxFont
            // 
            this.toolStripCbxFont.AutoSize = false;
            this.toolStripCbxFont.Items.AddRange(new object[] {
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "32",
            "34",
            "36"});
            this.toolStripCbxFont.Name = "toolStripCbxFont";
            this.toolStripCbxFont.Size = new System.Drawing.Size(60, 23);
            this.toolStripCbxFont.ToolTipText = "Font Size";
            this.toolStripCbxFont.TextChanged += new System.EventHandler(this.toolStripCbxFont_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnDelete
            // 
            this.toolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDelete.Image")));
            this.toolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDelete.Name = "toolStripBtnDelete";
            this.toolStripBtnDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDelete.Text = "toolStripButton1";
            this.toolStripBtnDelete.ToolTipText = "Delete Selected";
            this.toolStripBtnDelete.Click += new System.EventHandler(this.toolStripBtnDelete_Click);
            // 
            // toolStripBtnDeleteAll
            // 
            this.toolStripBtnDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDeleteAll.Image")));
            this.toolStripBtnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDeleteAll.Name = "toolStripBtnDeleteAll";
            this.toolStripBtnDeleteAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDeleteAll.Text = "toolStripButton2";
            this.toolStripBtnDeleteAll.ToolTipText = "Delete All";
            this.toolStripBtnDeleteAll.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnBringToBack
            // 
            this.toolStripBtnBringToBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnBringToBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBringToBack.Image")));
            this.toolStripBtnBringToBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBringToBack.Name = "toolStripBtnBringToBack";
            this.toolStripBtnBringToBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnBringToBack.Text = "Push To Back";
            this.toolStripBtnBringToBack.Click += new System.EventHandler(this.toolStripBtnBringToBack_Click);
            // 
            // toolStripBtnBringToFront
            // 
            this.toolStripBtnBringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnBringToFront.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBringToFront.Image")));
            this.toolStripBtnBringToFront.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBringToFront.Name = "toolStripBtnBringToFront";
            this.toolStripBtnBringToFront.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnBringToFront.Text = "Bring To Font";
            this.toolStripBtnBringToFront.Click += new System.EventHandler(this.toolStripBtnBringToFront_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dsViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(714, 385);
            this.splitContainer1.SplitterDistance = 546;
            this.splitContainer1.TabIndex = 3;
            // 
            // dsViewer1
            // 
            this.dsViewer1.Location = new System.Drawing.Point(0, 0);
            this.dsViewer1.Name = "dsViewer1";
            this.dsViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dsViewer1.SelectionRectAspectRatio = 0D;
            this.dsViewer1.Size = new System.Drawing.Size(543, 382);
            this.dsViewer1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(164, 385);
            this.propertyGrid1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 435);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Annotation Sample";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnEannotation;
        private System.Windows.Forms.ToolStripButton toolStripBtnRannotation;
        private System.Windows.Forms.ToolStripButton toolStripBtnTannotation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripCbxPen;
        private System.Windows.Forms.ToolStripLabel toolStripFill;
        private System.Windows.Forms.ToolStripLabel toolStripPen;
        private System.Windows.Forms.ToolStripLabel toolStripFont;
        private System.Windows.Forms.ToolStripComboBox toolStripCbxFont;
        private System.Windows.Forms.ToolStripButton toolStripBtnFill;
        private System.Windows.Forms.ToolStripButton toolStripBtnPen;
        private System.Windows.Forms.ToolStripButton toolStripBtnFont;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnDelete;
        private System.Windows.Forms.ToolStripButton toolStripBtnDeleteAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripBtnLannotation;
        private Dynamsoft.Forms.DSViewer dsViewer1;
        private System.Windows.Forms.ToolStripButton toolStripBtnBringToBack;
        private System.Windows.Forms.ToolStripButton toolStripBtnBringToFront;
    }
}

