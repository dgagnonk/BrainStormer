using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BrainStormerNoPlugins
{
    public partial class frmNote : Form
    {

        private string ID = "";
        private string title = "";
        private const string type = "note";
        private const string extension = ".txt";

        public frmNote(string ID, string title, string content)
        {
            InitializeComponent();

            this.title = title;
            this.Text = title;
            this.ID = ID;
            txtNote.Text = content;
            txtNote.TextChanged += TxtNote_TextChanged;
        }

        private void TxtNote_TextChanged(object sender, EventArgs e)
        {
            ProjectInfo.Dirty = true;
        }

        private void tmrSave_Tick(object sender, EventArgs e)
        {
            // Process will say it is in use if user types very quickly, but once they stop it will save
            try
            {
                ContentInfo cinfo = new ContentInfo(this.ID, this.title, type, extension);
                string json = JsonConvert.SerializeObject(cinfo);

                File.WriteAllText(ProjectInfo.ProjectPath + ID + ".json", json);
                File.WriteAllText(ProjectInfo.ProjectPath + ID + ".txt", txtNote.Text);
            }
            catch (Exception) { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (save.ShowDialog() == DialogResult.Cancel) return;
            File.WriteAllText(save.FileName, txtNote.Text);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (open.ShowDialog() == DialogResult.Cancel) return;
            txtNote.Text = File.ReadAllText(open.FileName);
        }
    }
}
