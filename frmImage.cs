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
using System.Windows.Forms;

namespace BrainStormerNoPlugins
{

    /*
     * Image window feature.
     * Lets you view image stretched to fit the window, or as the original size.
     * Very basic (as was intended).
     * It'd be cool to add zoom or something later.
     */

    public partial class frmImage : Form
    {

        private string ID = "";
        private string title = "Image";
        private string filepath = "";

        public frmImage(string ID, string title, string filepath)
        {
            InitializeComponent();

            this.ID = ID;
            this.title = title;
            this.filepath = filepath;

            this.Text = title;

            pbImage.Image = Image.FromFile(filepath);
            pbImage.Width = panImage.Width;
            pbImage.Height = panImage.Height;

            panImage.Resize += PanImage_Resize;
        }

        private void PanImage_Resize(object sender, EventArgs e)
        {
            pbImage.Width = panImage.Width;
            pbImage.Height = panImage.Height;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stretchImageToolStripMenuItem.Checked == true) return;
            else
            {
                stretchImageToolStripMenuItem.Checked = true;
                originalImageSizeToolStripMenuItem.Checked = false;

                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }          
        }

        private void originalImageSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImageSizeToolStripMenuItem.Checked == true) return;
            else
            {
                stretchImageToolStripMenuItem.Checked = false;
                originalImageSizeToolStripMenuItem.Checked = true;

                pbImage.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }
    }
}
