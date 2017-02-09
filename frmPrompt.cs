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
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BrainStormerNoPlugins
{

    /*
     * Form for all prompts, custom or otherwise
     * Features:
     *      - Add, edit, delete, clear prompts
     *      - Left pane is for questions, right pane is for answers
     */

    public partial class frmPrompt : Form
    {

        private string ID = "";
        private string title = "";
        private string type = "prompt";
        private const string extension = ".prompt";

        private List<Prompt> prompts = new List<Prompt>();

        // It's a bit complicated to load in a prompt
        public frmPrompt(string id, string title, string prompttype, string promptsjson = "")
        {
            InitializeComponent();

            this.ID = id;
            this.title = title;

            this.Text = title;
            this.type = prompttype;

            if (promptsjson != "")
            {
                prompts = JsonConvert.DeserializeObject<List<Prompt>>(promptsjson);
                foreach (Prompt p in prompts)
                {
                    lstQuestions.Items.Add(p.Question);
                }
            }
            else
            {
                // don't need a case for custom prompts because it'll just be blank
                // by default which is what we want for custom prompts
                if (prompttype == "character")
                {
                    string[] lines = Properties.Resources.character_prompts.Split(new char[] {'\n' });
                    foreach(string question in lines)
                    {
                        if (String.IsNullOrWhiteSpace(question)) continue;
                        lstQuestions.Items.Add(question);
                        prompts.Add(new Prompt(question, ""));
                    }
                }
                else if (prompttype == "location")
                {
                    string[] lines = Properties.Resources.location_prompts.Split(new char[] { '\n' });
                    foreach (string question in lines)
                    {
                        if (String.IsNullOrWhiteSpace(question)) continue;
                        lstQuestions.Items.Add(question);
                        prompts.Add(new Prompt(question, ""));
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show("Which question would you like to add?", "Question", "", null);
            if (result.OK)
            {
                lstQuestions.Items.Add(result.Text);
                lstQuestions.SelectedIndex = lstQuestions.Items.Count - 1;
                txtDescription.Text = "";

                prompts.Add(new Prompt(result.Text));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedIndex == -1) return;

            InputBoxResult result = InputBox.Show("Edit:", "Edit", lstQuestions.SelectedItem.ToString(), null);
            if (result.OK)
            {            
                int selectedindex = lstQuestions.SelectedIndex;
                string previousAnswer = prompts[selectedindex].Answer;

                lstQuestions.Items.RemoveAt(selectedindex);
                prompts.RemoveAt(selectedindex);

                lstQuestions.Items.Insert(selectedindex, result.Text);
                prompts.Insert(selectedindex, new Prompt(result.Text, previousAnswer));

                lstQuestions.SelectedIndex = selectedindex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all questions?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            lstQuestions.Items.Clear();
            prompts.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedIndex == -1) return;

            var result = MessageBox.Show("Are you sure you want to delete this question?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            lstQuestions.Items.Remove(lstQuestions.SelectedItem);
            prompts.RemoveAt(lstQuestions.SelectedIndex);
        }

        private string SerializePrompts()
        {
            string json = JsonConvert.SerializeObject(prompts);
            return json;
        }

        private void tmrSave_Tick(object sender, EventArgs e)
        {
            try
            {
                ContentInfo cinfo = new ContentInfo(this.ID, this.title, type, extension);
                string json = JsonConvert.SerializeObject(cinfo);

                File.WriteAllText(ProjectInfo.ProjectPath + ID + ".json", json);
                File.WriteAllText(ProjectInfo.ProjectPath + ID + ".prompt", SerializePrompts());
            }
            catch (Exception) { }
        }

        private void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(prompts.Count);
            try
            {
                txtDescription.Text = prompts[lstQuestions.SelectedIndex].Answer;
            }
            catch (Exception) { }
            
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(prompts.Count);

            if (lstQuestions.SelectedIndex == -1) return;

            // Lazy fix. Race condition. Prompts is not updated with the new prompt after adding fast enough before the textchanged event is fired.
            // You end up with an ArgumentOutOfRangeException.
            try
            {
                prompts[lstQuestions.SelectedIndex].Answer = txtDescription.Text;
            }
            catch (Exception) { }
            
        }
    }
}
