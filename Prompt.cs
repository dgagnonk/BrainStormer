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

using Newtonsoft.Json;

namespace BrainStormerNoPlugins
{

    /*
     * Basic object to be serialized into JSON. This takes care of any prompts, custom or not.
     * Prompts have the structure of a question, and an associated answer.
     * This class does not serialize itself, but can provide JSON for other parts of the software to
     * perform serialization.
     */

    public class Prompt
    {

        private string question = "";
        private string answer = "";

        public Prompt(string question, string defaultanswer = "")
        {
            this.question = question;
            this.answer = defaultanswer;
        }

        public string Question { get { return this.question; } set { this.question = value; } }
        public string Answer { get { return this.answer; } set { this.answer = value; } }

        public string GetJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
