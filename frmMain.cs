using System;
using System.Linq;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;

namespace BrainStormerNoPlugins
{

    public partial class frmMain : Form
    {

        // The type currently being added to the tree
        private string BeingAdded = "";
        private string AddingExtension = "";

        #region Constructor

        public frmMain()
        {
            InitializeComponent();

            txtTitle.GotFocus += TxtTitle_GotFocus;
            txtTitle.LostFocus += TxtTitle_LostFocus;
            txtTitle.KeyDown += TxtTitle_KeyDown;

            tvContent.MouseDown += TvContent_MouseDown;
            tvContent.NodeMouseDoubleClick += TvContent_NodeMouseDoubleClick;
            tvContent.ItemDrag += TvContent_ItemDrag;
            tvContent.DragEnter += TvContent_DragEnter;
            tvContent.DragDrop += TvContent_DragDrop;
            tvContent.AfterLabelEdit += TvContent_AfterLabelEdit;
            tvContent.KeyDown += TvContent_KeyDown;

            this.FormClosing += FrmMain_FormClosing;
        }





        #endregion

        #region Treeview Dragging and Dropping

        private void TvContent_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode NewNode;

            try
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                    TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                    NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                    if (DestinationNode == null && tvContent.Bounds.Contains(pt))
                    {
                        ((TreeView)sender).Nodes.Add((TreeNode)NewNode.Clone());
                    }
                    else
                    {
                        DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                        DestinationNode.Expand();
                    }

                    //Remove Original Node
                    NewNode.Remove();
                    ProjectInfo.Dirty = true;
                }
            }
            catch (NullReferenceException) { }

        }

        private void TvContent_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TvContent_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }


        #endregion

        #region Misc Form Events

        private void TxtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }

        private void TvContent_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ProjectInfo.Dirty = true;
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selected = tvContent.SelectedNode;
            var result = MessageBox.Show("Are you sure you would like to delete \"" + selected.Text + "\"?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            ContentInfo cinfo = JsonConvert.DeserializeObject<ContentInfo>(selected.Tag.ToString());
            string filepath = cinfo.ID + cinfo.Extension;

            tvContent.Nodes.Remove(selected);
            File.Delete(ProjectInfo.ProjectPath + "/" + filepath);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            AddContentToTree("Notes", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
            AddContentToTree("Chapters", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
            AddContentToTree("Characters", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
            AddContentToTree("Locations", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
        }

        private void TvContent_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ContentInfo cinfo = JsonConvert.DeserializeObject<ContentInfo>(e.Node.Tag.ToString());

            switch (cinfo.Type)
            {
                case "note":
                    frmNote noteform = new frmNote(cinfo.ID, cinfo.Title, File.ReadAllText(ProjectInfo.ProjectPath + "/" + cinfo.ID + cinfo.Extension));
                    noteform.MdiParent = this;
                    noteform.Show();
                    break;

                case "richtext":
                    frmRichText richtextform = new frmRichText(cinfo.ID, cinfo.Title, true);
                    richtextform.MdiParent = this;
                    richtextform.Show();
                    break;

                case "image":
                    frmImage imageform = new frmImage(cinfo.ID, cinfo.Title, ProjectInfo.ProjectPath + "/" + cinfo.ID + cinfo.Extension);
                    imageform.MdiParent = this;
                    imageform.Show();
                    break;

                default:
                    break;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(ProjectInfo.ProjectPath) && ProjectInfo.Dirty == true)
            {
                var result  = MessageBox.Show("Save current project before closing?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveProjectToolStripMenuItem.PerformClick();
                }
                else
                {
                    Directory.Delete(ProjectInfo.ProjectPath, true);
                }
            }
        }

        private void TxtTitle_LostFocus(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                txtTitle.Text = "Title";
            }
        }

        private void TxtTitle_GotFocus(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Title")
            {
                txtTitle.Text = "";
            }
        }

        private void TvContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRightClick.Show(tvContent, PointToClient(Cursor.Position));
            }
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvContent.SelectedNode = null;
        }

        #endregion

        #region Add Tree Content

        private void ShowTitlePanel()
        {
            panTitle.Visible = true;

            foreach (ToolStripMenuItem c in mnuRightClick.Items.OfType<ToolStripMenuItem>())
                c.Enabled = false;
        }

        private void AddContentToTree(string title, ContentInfo info)
        {

            TreeNode node = new TreeNode(title);

            switch (info.Type)
            {
                case "folder":
                    node.ImageIndex = 0;
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(ProjectIO.GenerateUniqueID(), title, "folder", "")); ;
                    break;

                case "note":
                    node.ImageIndex = 1;
         
                    string nodeid = ProjectIO.GenerateUniqueID();
                    frmNote noteform = new frmNote(nodeid, title, "");               
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(nodeid, title, "note", ".txt"));

                    noteform.MdiParent = this;
                    noteform.Text = title;
                    noteform.Show();
                    break;

                case "richtext":
                    node.ImageIndex = 2;

                    string nodeidRT = ProjectIO.GenerateUniqueID();
                    frmRichText richtextform = new frmRichText(nodeidRT, title, false);
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(nodeidRT, title, "richtext", ".rtf"));

                    richtextform.MdiParent = this;
                    richtextform.Text = title;
                    richtextform.Show();

                    break;

                default:
                    return;
            }

            node.SelectedImageIndex = node.ImageIndex;

            if (tvContent.SelectedNode == null)
            {
                tvContent.Nodes.Add(node);
            }
            else
            {
                tvContent.SelectedNode.Nodes.Add(node);
                tvContent.SelectedNode.Expand();
            }

            ProjectInfo.Dirty = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BeingAdded = "";
            AddingExtension = "";
            panTitle.Visible = false;
            txtTitle.Text = "Title";
            tvContent.Focus();
            foreach (ToolStripMenuItem c in mnuRightClick.Items.OfType<ToolStripMenuItem>())
                c.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ContentInfo info = new ContentInfo(ProjectIO.GenerateUniqueID(), txtTitle.Text, BeingAdded, AddingExtension);
            AddContentToTree(txtTitle.Text, info);

            btnCancel.PerformClick();
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "folder";
            AddingExtension = "";
        }

        private void addBasicTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "note";
            AddingExtension = ".txt";
        }

        private void addRichTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "richtext";
            AddingExtension = ".rtf";
        }

        #endregion

        #region Saving and Loading

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectIO.SaveTree(tvContent, ProjectInfo.ProjectPath + "tree.TREEINFO");

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "BrainStormer Project File (*.bpf)|*.bpf|All Files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName)) File.Delete(save.FileName);
                ZipFile.CreateFromDirectory(ProjectInfo.ProjectPath, save.FileName);
            }

            ProjectInfo.Dirty = false;

        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "BrainStormer Project File (*.bpf)|*.bpf|All Files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.Cancel) return;

            if (Directory.Exists(ProjectInfo.ProjectPath))
            {
                var result = MessageBox.Show("There is a project already open. Overwrite?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                Directory.Delete(ProjectInfo.ProjectPath, true);
            }

            ZipFile.ExtractToDirectory(open.FileName, ProjectInfo.ProjectPath);
            ProjectIO.LoadTree(tvContent, ProjectInfo.ProjectPath + "/tree.TREEINFO");

            BuildNodes(tvContent.Nodes);

            ProjectInfo.Dirty = false;
        }

        // Rebuilds the nodes with their proper images
        private void BuildNodes(TreeNodeCollection tnc)
        {
            foreach (TreeNode tn in tnc)
            {
                ContentInfo cinfo = JsonConvert.DeserializeObject<ContentInfo>(tn.Tag.ToString());

                if (cinfo.Type == "note") tn.ImageIndex = 1;              
                else if (cinfo.Type == "richtext") tn.ImageIndex = 2;

                tn.SelectedImageIndex = tn.ImageIndex;

                BuildNodes(tn.Nodes);
            }
        }



        #endregion

        #region Hotkeys

        // Hotkeys restricted to when tvContent is selected
        private void TvContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) // Del
            {
                deleteSelectedToolStripMenuItem.PerformClick();
            }
            else if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) // Ctrl + D
            {
                deselectAllToolStripMenuItem.PerformClick();
            }
            else if (e.KeyCode == Keys.F && Control.ModifierKeys == Keys.Alt) // Alt + F
            {
                addFolderToolStripMenuItem.PerformClick();
            }
            else if (e.KeyCode == Keys.T && Control.ModifierKeys == Keys.Alt) // Alt + T
            {
                addBasicTextToolStripMenuItem.PerformClick();
            }
            else if (e.KeyCode == Keys.R && Control.ModifierKeys == Keys.Alt) // Alt + R
            {
                addRichTextToolStripMenuItem.PerformClick();
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        // Global hotkeys across all of frmMain and within MDI forms
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S)) // Ctrl + S
            {
                saveProjectToolStripMenuItem.PerformClick();
            }
            else if (keyData == (Keys.Control | Keys.O)) // Ctrl + O
            {
                openProjectToolStripMenuItem.PerformClick();
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Form Management

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        #endregion


    }
}
