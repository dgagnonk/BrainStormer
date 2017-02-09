namespace BrainStormerNoPlugins
{
    partial class frmRichText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRichText));
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.wordCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letterCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtFind = new System.Windows.Forms.ToolStripTextBox();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnReplace = new System.Windows.Forms.ToolStripButton();
            this.btnSynopsis = new System.Windows.Forms.ToolStripButton();
            this.tmrSave = new System.Windows.Forms.Timer(this.components);
            this.panSynopsis = new System.Windows.Forms.Panel();
            this.txtSynopsis = new System.Windows.Forms.TextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTextToSpeech = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.panSynopsis.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbContent
            // 
            this.rtbContent.AcceptsTab = true;
            this.rtbContent.AutoWordSelection = true;
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.EnableAutoDragDrop = true;
            this.rtbContent.Location = new System.Drawing.Point(0, 25);
            this.rtbContent.Margin = new System.Windows.Forms.Padding(50, 50, 50, 3);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ShowSelectionMargin = true;
            this.rtbContent.Size = new System.Drawing.Size(735, 479);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.btnImport,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.toolStripSeparator3,
            this.btnFont,
            this.toolStripSeparator4,
            this.txtFind,
            this.btnFind,
            this.btnReplace,
            this.toolStripSeparator6,
            this.btnSynopsis,
            this.toolStripSeparator5,
            this.btnTextToSpeech});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(735, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::BrainStormerNoPlugins.Properties.Resources.import;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(60, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::BrainStormerNoPlugins.Properties.Resources.export;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(63, 22);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordCountToolStripMenuItem,
            this.letterCountToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::BrainStormerNoPlugins.Properties.Resources.count2;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // wordCountToolStripMenuItem
            // 
            this.wordCountToolStripMenuItem.Name = "wordCountToolStripMenuItem";
            this.wordCountToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.wordCountToolStripMenuItem.Text = "Word Count";
            this.wordCountToolStripMenuItem.Click += new System.EventHandler(this.wordCountToolStripMenuItem_Click);
            // 
            // letterCountToolStripMenuItem
            // 
            this.letterCountToolStripMenuItem.Name = "letterCountToolStripMenuItem";
            this.letterCountToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.letterCountToolStripMenuItem.Text = "Letter Count";
            this.letterCountToolStripMenuItem.Click += new System.EventHandler(this.letterCountToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBold
            // 
            this.btnBold.CheckOnClick = true;
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = global::BrainStormerNoPlugins.Properties.Resources.bold;
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Text = "toolStripButton1";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.CheckOnClick = true;
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = global::BrainStormerNoPlugins.Properties.Resources.italic;
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.Text = "toolStripButton1";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.CheckOnClick = true;
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = global::BrainStormerNoPlugins.Properties.Resources.underline;
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnUnderline.Text = "toolStripButton1";
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFont
            // 
            this.btnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(83, 22);
            this.btnFont.Text = "Font: N/A 0pt";
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txtFind
            // 
            this.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFind.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 25);
            // 
            // btnFind
            // 
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFind.Image = global::BrainStormerNoPlugins.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(23, 22);
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplace.Image = global::BrainStormerNoPlugins.Properties.Resources.replace;
            this.btnReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(23, 22);
            this.btnReplace.Text = "Replace";
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnSynopsis
            // 
            this.btnSynopsis.CheckOnClick = true;
            this.btnSynopsis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSynopsis.Image = ((System.Drawing.Image)(resources.GetObject("btnSynopsis.Image")));
            this.btnSynopsis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSynopsis.Name = "btnSynopsis";
            this.btnSynopsis.Size = new System.Drawing.Size(57, 22);
            this.btnSynopsis.Text = "Synopsis";
            this.btnSynopsis.Click += new System.EventHandler(this.btnSynopsis_Click);
            // 
            // tmrSave
            // 
            this.tmrSave.Enabled = true;
            this.tmrSave.Interval = 1000;
            this.tmrSave.Tick += new System.EventHandler(this.tmrSave_Tick);
            // 
            // panSynopsis
            // 
            this.panSynopsis.Controls.Add(this.txtSynopsis);
            this.panSynopsis.Location = new System.Drawing.Point(476, 25);
            this.panSynopsis.Name = "panSynopsis";
            this.panSynopsis.Size = new System.Drawing.Size(200, 100);
            this.panSynopsis.TabIndex = 3;
            this.panSynopsis.Visible = false;
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSynopsis.Location = new System.Drawing.Point(0, 0);
            this.txtSynopsis.Multiline = true;
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSynopsis.Size = new System.Drawing.Size(200, 100);
            this.txtSynopsis.TabIndex = 0;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTextToSpeech
            // 
            this.btnTextToSpeech.Image = ((System.Drawing.Image)(resources.GetObject("btnTextToSpeech.Image")));
            this.btnTextToSpeech.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTextToSpeech.Name = "btnTextToSpeech";
            this.btnTextToSpeech.Size = new System.Drawing.Size(103, 22);
            this.btnTextToSpeech.Text = "Text to Speech";
            this.btnTextToSpeech.Click += new System.EventHandler(this.btnTextToSpeech_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // frmRichText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 504);
            this.Controls.Add(this.panSynopsis);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRichText";
            this.Text = "Rich Text";
            this.Load += new System.EventHandler(this.frmRichText_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panSynopsis.ResumeLayout(false);
            this.panSynopsis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.Timer tmrSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem wordCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem letterCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnReplace;
        private System.Windows.Forms.ToolStripButton btnSynopsis;
        private System.Windows.Forms.Panel panSynopsis;
        private System.Windows.Forms.TextBox txtSynopsis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnTextToSpeech;
    }
}