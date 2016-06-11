using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BrainStormerNoPlugins
{
    public class ContentInfo
    {

        private string type = "";
        private string title = "";
        private string id = "";
        private string extension = "";

        public ContentInfo(string id, string title, string type, string extension)
        {
            this.id = id;
            this.title = title;
            this.type = type;
            this.extension = extension;
        }

        public string Type {  get { return this.type; } set { this.type = value; } }
        public string Title { get { return this.title; } set { this.title = value; } }
        public string ID {  get { return this.id; } set { this.id = value; } }
        public string Extension { get { return this.extension; } set { this.extension = value; } }

    }
}
