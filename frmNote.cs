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
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Speech.Synthesis;

namespace BrainStormerNoPlugins
{
    /*
     * Form for plaintext notes, saved as .txt in the project archive.
     * Features:
     *      - Basic text only (Notepad sort of thing)
     *      - Import/export from another document
     *      - Text to speech
     */

    public partial class frmNote : Form
    {

        private string ID = "";
        private string title = "";
        private const string type = "note";
        private const string extension = ".txt";

        private TextToSpeech voice;

        public frmNote(string ID, string title, string content)
        {
            InitializeComponent();

            this.title = title;
            this.Text = title;
            this.ID = ID;
            txtNote.Text = content;
            txtNote.TextChanged += TxtNote_TextChanged;

            this.FormClosing += FrmNote_FormClosing;

            voice = new TextToSpeech();

            //voice.SpeakCompleted += Voice_SpeakCompleted;
        }

        private void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            voice.StopSpeech();
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

        private void btnTextToSpeech_Click(object sender, EventArgs e)
        { 
            if (voice.GetState() == SynthesizerState.Speaking)
            {
                voice.StopSpeech();
                return;
            }

            if (txtNote.Text.Length < 1) return;

            string toRead = "";

            if (txtNote.SelectedText.Length < 1)
            {
                toRead = txtNote.Text;
            }
            else
            {
                toRead = txtNote.SelectedText;
            }

            voice.SayText(toRead);
        }
    }
}
