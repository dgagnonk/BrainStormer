namespace BrainStormerNoPlugins
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvContent = new System.Windows.Forms.TreeView();
            this.ilContent = new System.Windows.Forms.ImageList(this.components);
            this.panTitle = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.mnuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuFormManager = new System.Windows.Forms.ToolStripDropDownButton();
            this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBasicTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRichTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panTitle.SuspendLayout();
            this.mnuRightClick.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvContent);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.panTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 557);
            this.panel1.TabIndex = 1;
            // 
            // tvContent
            // 
            this.tvContent.AllowDrop = true;
            this.tvContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContent.HotTracking = true;
            this.tvContent.ImageIndex = 0;
            this.tvContent.ImageList = this.ilContent;
            this.tvContent.LabelEdit = true;
            this.tvContent.Location = new System.Drawing.Point(0, 44);
            this.tvContent.Name = "tvContent";
            this.tvContent.SelectedImageIndex = 0;
            this.tvContent.Size = new System.Drawing.Size(236, 488);
            this.tvContent.TabIndex = 0;
            // 
            // ilContent
            // 
            this.ilContent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilContent.ImageStream")));
            this.ilContent.TransparentColor = System.Drawing.Color.Transparent;
            this.ilContent.Images.SetKeyName(0, "1464756752_folder.png");
            this.ilContent.Images.SetKeyName(1, "note.png");
            this.ilContent.Images.SetKeyName(2, "type_filled_25px.png");
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.btnCancel);
            this.panTitle.Controls.Add(this.btnOK);
            this.panTitle.Controls.Add(this.txtTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(236, 44);
            this.panTitle.TabIndex = 3;
            this.panTitle.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(140, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(190, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(34, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(13, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(126, 22);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Title";
            // 
            // mnuRightClick
            // 
            this.mnuRightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deselectAllToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addFolderToolStripMenuItem,
            this.addBasicTextToolStripMenuItem,
            this.addRichTextToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem});
            this.mnuRightClick.Name = "mnuRightClick";
            this.mnuRightClick.Size = new System.Drawing.Size(192, 198);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormManager});
            this.toolStrip1.Location = new System.Drawing.Point(0, 532);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(236, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuFormManager
            // 
            this.mnuFormManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuFormManager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileVerticallyToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.mnuFormManager.Image = global::BrainStormerNoPlugins.Properties.Resources.cascade;
            this.mnuFormManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFormManager.Name = "mnuFormManager";
            this.mnuFormManager.Size = new System.Drawing.Size(29, 22);
            this.mnuFormManager.Text = "Arrange Windows";
            // 
            // tileVerticallyToolStripMenuItem
            // 
            this.tileVerticallyToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.vertically2;
            this.tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
            this.tileVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileVerticallyToolStripMenuItem.Text = "Tile Vertically";
            this.tileVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.horizontally;
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontally";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.cascade2;
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.cancel_25px;
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.folder;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // addBasicTextToolStripMenuItem
            // 
            this.addBasicTextToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.note;
            this.addBasicTextToolStripMenuItem.Name = "addBasicTextToolStripMenuItem";
            this.addBasicTextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.addBasicTextToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addBasicTextToolStripMenuItem.Text = "Add Basic Text";
            this.addBasicTextToolStripMenuItem.Click += new System.EventHandler(this.addBasicTextToolStripMenuItem_Click);
            // 
            // addRichTextToolStripMenuItem
            // 
            this.addRichTextToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.richtext;
            this.addRichTextToolStripMenuItem.Name = "addRichTextToolStripMenuItem";
            this.addRichTextToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.addRichTextToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addRichTextToolStripMenuItem.Text = "Add Rich Text";
            this.addRichTextToolStripMenuItem.Click += new System.EventHandler(this.addRichTextToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.save32;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.note_25px;
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 557);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "BrainStormer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.mnuRightClick.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvContent;
        private System.Windows.Forms.ContextMenuStrip mnuRightClick;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addBasicTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRichTextToolStripMenuItem;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ImageList ilContent;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton mnuFormManager;
        private System.Windows.Forms.ToolStripMenuItem tileVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
    }
}

