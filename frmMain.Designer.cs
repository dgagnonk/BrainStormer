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
            this.panTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tvContent = new System.Windows.Forms.TreeView();
            this.mnuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBasicTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRichTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCharacterPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLocationPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilContent = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuFormManager = new System.Windows.Forms.ToolStripDropDownButton();
            this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panRecent = new System.Windows.Forms.Panel();
            this.btnCancelLoad = new System.Windows.Forms.Button();
            this.btnLoadRecent = new System.Windows.Forms.Button();
            this.lstRecentProjects = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrSnapshots = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnBlog = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panTitle.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mnuRightClick.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panRecent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvContent);
            this.panel1.Controls.Add(this.panTitle);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 600);
            this.panel1.TabIndex = 1;
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.label1);
            this.panTitle.Controls.Add(this.btnCancel);
            this.panTitle.Controls.Add(this.btnOK);
            this.panTitle.Controls.Add(this.txtTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 60);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(236, 51);
            this.panTitle.TabIndex = 3;
            this.panTitle.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter a content title:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(192, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(34, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 21);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(126, 22);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 60);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BrainStormerNoPlugins.Properties.Resources.right_click;
            this.pictureBox1.Location = new System.Drawing.Point(15, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 42);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tvContent
            // 
            this.tvContent.AllowDrop = true;
            this.tvContent.ContextMenuStrip = this.mnuRightClick;
            this.tvContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContent.HotTracking = true;
            this.tvContent.ImageIndex = 0;
            this.tvContent.ImageList = this.ilContent;
            this.tvContent.LabelEdit = true;
            this.tvContent.Location = new System.Drawing.Point(0, 111);
            this.tvContent.Name = "tvContent";
            this.tvContent.SelectedImageIndex = 0;
            this.tvContent.Size = new System.Drawing.Size(236, 464);
            this.tvContent.TabIndex = 0;
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
            this.addImageToolStripMenuItem,
            this.addRichTextToolStripMenuItem,
            this.addCharacterPromptToolStripMenuItem,
            this.addLocationPromptToolStripMenuItem,
            this.addCustomPromptToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem});
            this.mnuRightClick.Name = "mnuRightClick";
            this.mnuRightClick.Size = new System.Drawing.Size(192, 302);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
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
            // addImageToolStripMenuItem
            // 
            this.addImageToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.image;
            this.addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
            this.addImageToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addImageToolStripMenuItem.Text = "Add Image";
            this.addImageToolStripMenuItem.Click += new System.EventHandler(this.addImageToolStripMenuItem_Click);
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
            // addCharacterPromptToolStripMenuItem
            // 
            this.addCharacterPromptToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.character;
            this.addCharacterPromptToolStripMenuItem.Name = "addCharacterPromptToolStripMenuItem";
            this.addCharacterPromptToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addCharacterPromptToolStripMenuItem.Text = "Add Character";
            this.addCharacterPromptToolStripMenuItem.Click += new System.EventHandler(this.addCharacterPromptToolStripMenuItem_Click);
            // 
            // addLocationPromptToolStripMenuItem
            // 
            this.addLocationPromptToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.location;
            this.addLocationPromptToolStripMenuItem.Name = "addLocationPromptToolStripMenuItem";
            this.addLocationPromptToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addLocationPromptToolStripMenuItem.Text = "Add Location";
            this.addLocationPromptToolStripMenuItem.Click += new System.EventHandler(this.addLocationPromptToolStripMenuItem_Click);
            // 
            // addCustomPromptToolStripMenuItem
            // 
            this.addCustomPromptToolStripMenuItem.Image = global::BrainStormerNoPlugins.Properties.Resources.custom;
            this.addCustomPromptToolStripMenuItem.Name = "addCustomPromptToolStripMenuItem";
            this.addCustomPromptToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.addCustomPromptToolStripMenuItem.Text = "Add Custom Prompt";
            this.addCustomPromptToolStripMenuItem.Click += new System.EventHandler(this.addCustomPromptToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(188, 6);
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
            // ilContent
            // 
            this.ilContent.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilContent.ImageStream")));
            this.ilContent.TransparentColor = System.Drawing.Color.Transparent;
            this.ilContent.Images.SetKeyName(0, "1464756752_folder.png");
            this.ilContent.Images.SetKeyName(1, "note.png");
            this.ilContent.Images.SetKeyName(2, "type_filled_25px.png");
            this.ilContent.Images.SetKeyName(3, "mms_25px.png");
            this.ilContent.Images.SetKeyName(4, "edit_user_26px.png");
            this.ilContent.Images.SetKeyName(5, "globe_25px.png");
            this.ilContent.Images.SetKeyName(6, "custom.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormManager,
            this.btnBlog});
            this.toolStrip1.Location = new System.Drawing.Point(0, 575);
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
            // panRecent
            // 
            this.panRecent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panRecent.Controls.Add(this.btnCancelLoad);
            this.panRecent.Controls.Add(this.btnLoadRecent);
            this.panRecent.Controls.Add(this.lstRecentProjects);
            this.panRecent.Controls.Add(this.label2);
            this.panRecent.Location = new System.Drawing.Point(325, 150);
            this.panRecent.Name = "panRecent";
            this.panRecent.Size = new System.Drawing.Size(427, 274);
            this.panRecent.TabIndex = 3;
            this.panRecent.Visible = false;
            // 
            // btnCancelLoad
            // 
            this.btnCancelLoad.Location = new System.Drawing.Point(330, 84);
            this.btnCancelLoad.Name = "btnCancelLoad";
            this.btnCancelLoad.Size = new System.Drawing.Size(75, 23);
            this.btnCancelLoad.TabIndex = 3;
            this.btnCancelLoad.Text = "Cancel";
            this.btnCancelLoad.UseVisualStyleBackColor = true;
            this.btnCancelLoad.Click += new System.EventHandler(this.btnCancelLoad_Click);
            // 
            // btnLoadRecent
            // 
            this.btnLoadRecent.Location = new System.Drawing.Point(330, 55);
            this.btnLoadRecent.Name = "btnLoadRecent";
            this.btnLoadRecent.Size = new System.Drawing.Size(75, 23);
            this.btnLoadRecent.TabIndex = 2;
            this.btnLoadRecent.Text = "Load";
            this.btnLoadRecent.UseVisualStyleBackColor = true;
            this.btnLoadRecent.Click += new System.EventHandler(this.btnLoadRecent_Click);
            // 
            // lstRecentProjects
            // 
            this.lstRecentProjects.FormattingEnabled = true;
            this.lstRecentProjects.HorizontalScrollbar = true;
            this.lstRecentProjects.Location = new System.Drawing.Point(21, 55);
            this.lstRecentProjects.Name = "lstRecentProjects";
            this.lstRecentProjects.Size = new System.Drawing.Size(290, 186);
            this.lstRecentProjects.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Load Recent Project";
            // 
            // tmrSnapshots
            // 
            this.tmrSnapshots.Interval = 300000;
            this.tmrSnapshots.Tick += new System.EventHandler(this.tmrSnapshots_Tick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 48);
            this.label3.TabIndex = 1;
            this.label3.Text = "Right-click the data tree below to begin.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBlog
            // 
            this.btnBlog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBlog.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnBlog.Image = ((System.Drawing.Image)(resources.GetObject("btnBlog.Image")));
            this.btnBlog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBlog.Name = "btnBlog";
            this.btnBlog.Size = new System.Drawing.Size(185, 22);
            this.btnBlog.Text = "Click to visit the blog for updates";
            this.btnBlog.ToolTipText = "Blog";
            this.btnBlog.Click += new System.EventHandler(this.btnBlog_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panRecent);
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mnuRightClick.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panRecent.ResumeLayout(false);
            this.panRecent.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem addImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCharacterPromptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLocationPromptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomPromptToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panRecent;
        private System.Windows.Forms.Button btnCancelLoad;
        private System.Windows.Forms.Button btnLoadRecent;
        private System.Windows.Forms.ListBox lstRecentProjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrSnapshots;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnBlog;
    }
}

