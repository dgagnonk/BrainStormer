using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainStormerNoPlugins
{
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

        }
    }
}
