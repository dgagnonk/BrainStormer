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
using System.IO;

namespace BrainStormerNoPlugins
{

    /*
     * Simple class that can spit out some project info, like the current project's filepath.
     */
    public static class ProjectInfo
    {

        private static string projectPath = Environment.CurrentDirectory + "/Temp/";

        public static bool Dirty = false;

        public static string ProjectPath
        {
            get
            {
                if (Directory.Exists(Environment.CurrentDirectory + "/Temp/") == false)
                {
                    DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + "/Temp/");
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }

                return projectPath;
            }
        }

    }
}

