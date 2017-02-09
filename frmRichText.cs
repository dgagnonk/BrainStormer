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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

namespace BrainStormerNoPlugins
{

    /*
     * Rich text editor
     * Saves files in the project archive as .rtf
     * Features:
     *      - Import/Export text from another document
     *      - Text formatting (simple)
     *      - Word count, letter count
     *      - Text search, replace
     *      - Document synopsis
     *      - Text to speech
     */

    public partial class frmRichText : Form
    {

        

        private bool Bold = false;
        private bool Italic = false;
        private bool Underline = false;

        private string title = "Rich Text";
        private string ID = "";

        private int FindIndex = -1;

        private TextToSpeech voice;

        #region Constructor

        public frmRichText(string ID, string title, bool LoadFile)
        {
            InitializeComponent();

            this.title = title;
            this.ID = ID;
            this.Text = title;

            voice = new TextToSpeech();

            if (LoadFile == true)
            {
                rtbContent.LoadFile(ProjectInfo.ProjectPath + "/" + ID + ".rtf");
                try
                {
                    txtSynopsis.Text = File.ReadAllText(ProjectInfo.ProjectPath + "/" + ID + "synopsis.txt"); // load synopsis
                }
                catch (FileNotFoundException) { txtSynopsis.Text = ""; }

                RefreshFontLabel();
            }
                

            rtbContent.SelectionChanged += RtbContent_SelectionChanged;
            rtbContent.KeyDown += RtbContent_KeyDown;

            txtSynopsis.LostFocus += TxtSynopsis_LostFocus;

            this.FormClosing += FrmRichText_FormClosing;
        }

        private void FrmRichText_FormClosing(object sender, FormClosingEventArgs e)
        {
            voice.StopSpeech();
        }





        #endregion

        #region Save Timer, Import/Export

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Rich Text Files (*.rtf)|*.rtf|Word Document (*.doc)|*.doc|All files (*.*)|*.*";

            if (save.ShowDialog() == DialogResult.Cancel) return;

            rtbContent.SaveFile(save.FileName);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Rich Text Files (*.rtf)|*.rtf|Word Document (*.doc)|*.doc|All files (*.*)|*.*";

            if (open.ShowDialog() == DialogResult.Cancel) return;

            rtbContent.LoadFile(open.FileName);
        }

        private void tmrSave_Tick(object sender, EventArgs e)
        {
            // Process in use error will come up if user types too fast, we don't really care about that
            try
            {
                rtbContent.SaveFile(ProjectInfo.ProjectPath + "/" + this.ID + ".rtf");
                File.WriteAllText(ProjectInfo.ProjectPath + "/" + this.ID + "synopsis.txt", txtSynopsis.Text);
            }
            catch (Exception) { }
        }

        #endregion

        #region Counts

        // Obtained from http://stackoverflow.com/questions/8784517/counting-number-of-words-in-c-sharp
        private int WordCount(string text)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private int LetterCount(string text)
        {
            return text.Count<char>(char.IsLetter);
        }

        private void wordCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There are " + WordCount(rtbContent.Text) + " words in this document.", "Word Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void letterCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There are " + LetterCount(rtbContent.Text) + " letters in this document.", "Letter Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Font Styles

        private void btnItalic_Click(object sender, EventArgs e)
        {
            Italic = btnItalic.Checked;
            rtbContent.SelectionFont = new Font(rtbContent.Font, rtbContent.SelectionFont.Style | GetFontStyle(Bold, Italic, Underline));
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Bold = btnBold.Checked;
            rtbContent.SelectionFont = new Font(rtbContent.Font, rtbContent.SelectionFont.Style | GetFontStyle(Bold, Italic, Underline));
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Underline = btnUnderline.Checked;
            rtbContent.SelectionFont = new Font(rtbContent.Font, rtbContent.SelectionFont.Style | GetFontStyle(Bold, Italic, Underline));
        }

        private void RtbContent_SelectionChanged(object sender, EventArgs e)
        {
            FindIndex = rtbContent.SelectionStart;

            if (rtbContent.SelectionFont == null)
            {
                btnBold.CheckState = CheckState.Indeterminate;
                btnItalic.CheckState = CheckState.Indeterminate;
                btnUnderline.CheckState = CheckState.Indeterminate;
                return;
            }

            btnBold.Checked = (rtbContent.SelectionFont.Style & FontStyle.Bold) == FontStyle.Bold;
            btnItalic.Checked = (rtbContent.SelectionFont.Style & FontStyle.Italic) == FontStyle.Italic;
            btnUnderline.Checked = (rtbContent.SelectionFont.Style & FontStyle.Underline) == FontStyle.Underline;

            RefreshFontLabel();
        }



        private FontStyle GetFontStyle(bool bold, bool italic, bool underline)
        {
            FontStyle style;
            if (bold && !italic && !underline) // only bold
                style = FontStyle.Bold;
            else if (bold && italic && !underline) // bold and italic
                style = (FontStyle.Bold | FontStyle.Italic);
            else if (bold && !italic && underline) // bold and underline
                style = (FontStyle.Bold | FontStyle.Underline);
            else if (bold && italic && underline) // bold, italic, and underline
                style = (FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            else if (!bold && italic && !underline) // italic only
                style = FontStyle.Italic;
            else if (!bold && italic && underline) // italic and underline
                style = (FontStyle.Italic | FontStyle.Underline);
            else if (!bold && !italic && underline) // only underline
                style = FontStyle.Underline;
            else
                style = FontStyle.Regular; // regular

            return style;
        }


        #endregion

        #region Change Font

        private void frmRichText_Load(object sender, EventArgs e)
        {
            RefreshFontLabel();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.Cancel) return;

            rtbContent.Font = fd.Font;
            RefreshFontLabel();

        }

        private void RefreshFontLabel()
        {
            btnFont.Text = rtbContent.Font.Name + " " + rtbContent.Font.SizeInPoints.ToString() + "pt";
        }

        #endregion

        #region Hotkeys

        private void RtbContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B && Control.ModifierKeys == Keys.Control)
                btnBold.PerformClick();
            else if (e.KeyCode == Keys.I && Control.ModifierKeys == Keys.Control)
                btnItalic.PerformClick();
            else if (e.KeyCode == Keys.U && Control.ModifierKeys == Keys.Control)
                btnUnderline.PerformClick();
        }

        #endregion

        #region Find Text

        private int FindText(string str, int start = 0)
        {
            int startIndex = rtbContent.Find(str, start, RichTextBoxFinds.None);
            if (startIndex == -1)
            {
                MessageBox.Show("Text not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            return startIndex;

            //rtbContent.Select(startIndex)
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindIndex = FindText(txtFind.Text, FindIndex) + txtFind.Text.Length;
        }

        #endregion

        #region Replace Text

        private void btnReplace_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show("What would you like to replace \"" + txtFind.Text + "\" with?", "Replace", "", null);
            if (result.OK)
            {
                if (rtbContent.SelectionStart == -1)
                    rtbContent.Text.Replace(txtFind.Text, result.Text);
                else
                    rtbContent.SelectedText.Replace(txtFind.Text, result.Text);
            }
        }

        #endregion

        #region Misc Events

        private void btnSynopsis_Click(object sender, EventArgs e)
        {
            panSynopsis.Visible = btnSynopsis.Checked;
        }

        private void TxtSynopsis_LostFocus(object sender, EventArgs e)
        {
            panSynopsis.Visible = false;
            btnSynopsis.Checked = false;
        }

        #endregion

        #region Text to speech

        private void btnTextToSpeech_Click(object sender, EventArgs e)
        {
            if (voice.GetState() == SynthesizerState.Speaking)
            {
                voice.StopSpeech();
                return;
            }

            if (rtbContent.Text.Length < 1) return;

            string toRead = "";

            if (rtbContent.SelectedText.Length < 1)
            {
                toRead = rtbContent.Text;
            }
            else
            {
                toRead = rtbContent.SelectedText;
            }

            voice.SayText(toRead);
        }

        #endregion
    }
}
