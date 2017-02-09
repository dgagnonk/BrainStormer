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

namespace BrainStormerNoPlugins
{
    public class ContentInfo
    {

        /*
         * Serializable class object used in the project archive for pretty much everything except for Prompts.
         * 
         */

        private string type = "";
        private string title = "";
        private string id = "";
        private string extension = "";
        private string other = "";

        public ContentInfo(string id, string title, string type, string extension, string other = "")
        {
            this.id = id;
            this.title = title;
            this.type = type;
            this.extension = extension;

            this.other = other;
        }

        // Content type (rich text, simple text, etc.)
        public string Type {  get { return this.type; } set { this.type = value; } }
        public string Title { get { return this.title; } set { this.title = value; } }

        // Unique ID assigned
        public string ID {  get { return this.id; } set { this.id = value; } }

        // File extension
        public string Extension { get { return this.extension; } set { this.extension = value; } }

        // Essentially a "tag". Can contain any other pertinant info.
        public string OtherInfo { get { return this.other; } set { this.other = value; } }

    }
}
