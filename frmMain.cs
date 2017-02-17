/*
    BrainStormer: Brainstorm your writing.
    Copyright (C) 2015-2017  Daniel Gagnon-King

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace BrainStormerNoPlugins
{
    /*
     * Main form
     * Has project hierarchy on the left, different tool/feature windows appear on the right.
     * This project uses MDI (Multi-Document-Interface).
     * Toolbar at the bottom of the TreeView allows for organizing windows in a few basic ways.
     */

    public partial class frmMain : Form
    {

        /* Latest changes:
        *   - Image content type implemented
        *   - Buggy tree right click fixed
        */




        // The type currently being added to the tree
        private string BeingAdded = "";
        private string AddingExtension = "";

        private List<string> recentProjects = new List<string>();

        private struct RecentProjects
        {
            public string[] files;
        }

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
            tvContent.NodeMouseClick += TvContent_NodeMouseClick;

            panRecent.LostFocus += PanRecent_LostFocus;

            this.FormClosing += FrmMain_FormClosing;

            panRecent.Visible = true;
            tvContent.Enabled = false;

            try
            {
                // Code for recent projects panel that appears on startup
                recentProjects = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(Environment.CurrentDirectory + "recentprojects.json"));
                for (int i = 0; i < recentProjects.Count; i++)
                {
                    if (lstRecentProjects.Items.Contains(recentProjects[i]))
                    {
                        recentProjects.RemoveAt(i);
                        continue;
                    }
                    lstRecentProjects.Items.Add(recentProjects[i]);
                }

            } catch (FileNotFoundException) { recentProjects = new List<string>(); }    
        }



        #endregion

        #region Treeview Dragging and Dropping

        // The following TreeView events allow to move the TreeView items around, and for the control
        // to remember the new order of items.

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

        private void btnBlog_Click(object sender, EventArgs e)
        {
            Process.Start("http://rarewaffles.tumblr.com/");
        }
        private void TvContent_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvContent.SelectedNode = e.Node;
        }

        // Simple hotkeys for entering element titles into the TreeView
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

        // Content present in the tree on-load
        private void frmMain_Load(object sender, EventArgs e)
        {
            AddContentToTree("Notes", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
            AddContentToTree("Chapters", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
            AddContentToTree("Characters", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));
            AddContentToTree("Locations", new ContentInfo(ProjectIO.GenerateUniqueID(), "Notes", "folder", ""));

            ProjectInfo.Dirty = false;

            panRecent.Visible = true;
        }

        // Opens a new window with the proper content type as outlined by the switch statement
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

                case "character":
                    frmPrompt promptform = new frmPrompt(cinfo.ID, cinfo.Title, "character", File.ReadAllText(ProjectInfo.ProjectPath + "/" + cinfo.ID + cinfo.Extension));
                    promptform.MdiParent = this;
                    promptform.Show();
                    break;

                case "location":
                    frmPrompt promptform2 = new frmPrompt(cinfo.ID, cinfo.Title, "location", File.ReadAllText(ProjectInfo.ProjectPath + "/" + cinfo.ID + cinfo.Extension));
                    promptform2.MdiParent = this;
                    promptform2.Show();
                    break;

                case "customprompt":
                    frmPrompt promptform3 = new frmPrompt(cinfo.ID, cinfo.Title, "customprompt", File.ReadAllText(ProjectInfo.ProjectPath + "/" + cinfo.ID + cinfo.Extension));
                    promptform3.MdiParent = this;
                    promptform3.Show();
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

            File.WriteAllText(Environment.CurrentDirectory + "recentprojects.json", JsonConvert.SerializeObject(recentProjects));
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
            //if (e.Button == MouseButtons.Right)
            //{
            //    mnuRightClick.Show(tvContent, PointToClient(Cursor.Position));
            //}
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
            txtTitle.Focus();

            foreach (ToolStripMenuItem c in mnuRightClick.Items.OfType<ToolStripMenuItem>())
                c.Enabled = false;
        }

        // Add node properly to TreeView. Takes advantage of the "tag" property to help load relevant info into the 
        // appropriate feature.
        private void AddContentToTree(string title, ContentInfo info)
        {
            tmrSnapshots.Enabled = true;
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

                case "image":
                    node.ImageIndex = 3;

                    string nodeidimg = ProjectIO.GenerateUniqueID();
                    FileInfo imageinfo = null;
                    using (OpenFileDialog open = new OpenFileDialog())
                    {
                        open.Filter = "PNG Images (*.png)|*.png|JPEG Images (*.jpg)|*.jpg|Bitmap Images (*.bmp)|*.bmp|GIF Images (*.gif)|*.gif|All Files (*.*)|*.*";
                        if (open.ShowDialog() == DialogResult.Cancel) return;

                        imageinfo = new FileInfo(open.FileName);
                        File.Copy(open.FileName, ProjectInfo.ProjectPath + "/" + nodeidimg + imageinfo.Extension);
                    }

                    frmImage imageform = new frmImage(nodeidimg, title, ProjectInfo.ProjectPath + "/" + nodeidimg + imageinfo.Extension);
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(nodeidimg, title, "image", imageinfo.Extension));

                    imageform.MdiParent = this;
                    imageform.Text = title;
                    imageform.Show();

                    break;

                case "character":
                    node.ImageIndex = 4;

                    string nodeidchar = ProjectIO.GenerateUniqueID();
                    frmPrompt promptform = new frmPrompt(nodeidchar, title, "character");
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(nodeidchar, title, "character", ".prompt"));

                    promptform.MdiParent = this;
                    promptform.Text = title;
                    promptform.Show();

                    break;

                case "location":
                    node.ImageIndex = 5;

                    string nodeidloc = ProjectIO.GenerateUniqueID();
                    frmPrompt promptform2 = new frmPrompt(nodeidloc, title, "location");
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(nodeidloc, title, "location", ".prompt"));

                    promptform2.MdiParent = this;
                    promptform2.Text = title;
                    promptform2.Show();

                    break;

                case "customprompt":
                    node.ImageIndex = 6;

                    string nodeidprompt = ProjectIO.GenerateUniqueID();
                    frmPrompt promptform3 = new frmPrompt(nodeidprompt, title, "customprompt");
                    node.Tag = JsonConvert.SerializeObject(new ContentInfo(nodeidprompt, title, "customprompt", ".prompt"));

                    promptform3.MdiParent = this;
                    promptform3.Text = title;
                    promptform3.Show();

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

        private void addImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "image";
            AddingExtension = ""; // no extension because we pull that from the openfiledialog prompt
        }

        private void addCharacterPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "character";
            AddingExtension = ".prompt";
        }

        private void addLocationPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "location";
            AddingExtension = ".prompt";
        }

        private void addCustomPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTitlePanel();
            BeingAdded = "customprompt";
            AddingExtension = ".prompt";
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
                //ZipFile.CreateFromDirectory(ProjectInfo.ProjectPath, save.FileName);

                ProjectIO.CreateProjectFileUnix(ProjectInfo.ProjectPath, save.FileName);
            }

            ProjectInfo.Dirty = false;



            recentProjects.Add(save.FileName);

        }

        // TriggerDirty = makes project clean (ProjectInfo.Dirty = false)
        public void ManualSaveProject(string path, bool TriggerDirty)
        {
            ProjectIO.SaveTree(tvContent, ProjectInfo.ProjectPath + "tree.TREEINFO");

            if (File.Exists(path)) File.Delete(path);
            ProjectIO.CreateProjectFileUnix(ProjectInfo.ProjectPath, path);

            if (TriggerDirty == true) ProjectInfo.Dirty = false;
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject(true);
        }

        // "manual" file opening function with some options so we can load recent projects properly
        private void OpenProject(bool useDialog, string manualFileName = "none")
        {
            try
            {
                string filename = "";

                if (useDialog)
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

                    filename = open.FileName;
                }
                else
                {
                    filename = manualFileName;
                }

                if (manualFileName == "")
                {
                    MessageBox.Show("Error loading file. Blank filename.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Directory.Exists(ProjectInfo.ProjectPath)) Directory.Delete(ProjectInfo.ProjectPath, true);

                ProjectIO.ExtractZipFile(filename, "", ProjectInfo.ProjectPath);
                //ZipFile.ExtractToDirectory(filename, ProjectInfo.ProjectPath);
                ProjectIO.LoadTree(tvContent, ProjectInfo.ProjectPath + "/tree.TREEINFO");

                BuildNodes(tvContent.Nodes);

                ProjectInfo.Dirty = false;
                recentProjects.Add(filename);

            } catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorized access to the files in BrainStormer's project directory. Is the file in use? Note: Google Drive may list files as unsyncable on poor internet connections while still 'using' those files. This is a common issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         
        }


        // Rebuilds the nodes with their proper images
        private void BuildNodes(TreeNodeCollection tnc)
        {
            foreach (TreeNode tn in tnc)
            {
                ContentInfo cinfo = JsonConvert.DeserializeObject<ContentInfo>(tn.Tag.ToString());

                if (cinfo.Type == "note") tn.ImageIndex = 1;
                else if (cinfo.Type == "richtext") tn.ImageIndex = 2;
                else if (cinfo.Type == "image") tn.ImageIndex = 3;
                else if (cinfo.Type == "character") tn.ImageIndex = 4;
                else if (cinfo.Type == "location") tn.ImageIndex = 5;
                else if (cinfo.Type == "customprompt") tn.ImageIndex = 6;

                tn.SelectedImageIndex = tn.ImageIndex;

                BuildNodes(tn.Nodes);
            }
        }



        #endregion

        #region Hotkeys

        // HotKeys for the TreeView so that you don't always have to use the mouse.

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

        #region Recent Projects

        private void btnLoadRecent_Click(object sender, EventArgs e)
        {
            if (lstRecentProjects.SelectedIndex == -1) return;

            OpenProject(false, lstRecentProjects.SelectedItem.ToString());
            panRecent.Visible = false;
            tvContent.Enabled = true;
        }

        private void btnCancelLoad_Click(object sender, EventArgs e)
        {
            panRecent.Visible = false;
            tvContent.Enabled = true;
        }

        private void PanRecent_LostFocus(object sender, EventArgs e)
        {
            panRecent.Visible = false;
        }


        #endregion

        #region Snapshots

        private void tmrSnapshots_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.CurrentDirectory + "/snapshots/") == false)
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/snapshots/");
            }

            if (Directory.GetFiles(Environment.CurrentDirectory + "/snapshots/").Length > 100)
            {
                foreach (var fi in new DirectoryInfo(Environment.CurrentDirectory + "/snapshots/").GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(500))
                    fi.Delete();
            }

            ManualSaveProject(Environment.CurrentDirectory + "/snapshots/" + FormatDateForSnapshots(), false);
        }

        private string FormatDateForSnapshots()
        {
            return DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year + ", " + DateTime.Now.Hour.ToString("00") + ";" + DateTime.Now.Minute.ToString("00") + ";" + DateTime.Now.Second.ToString("00") + ".bpf";
        }

        #endregion



    }
}
