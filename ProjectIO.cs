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

// Note: Sources in this file were obtained from a third party. They are marked accordingly.

using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace BrainStormerNoPlugins
{

    /*
     * Special IO for saving and loading projects. Deals properly with the project files,
     * which are really just fancy ZIP files containing the data we want.
     */
    public static class ProjectIO
    {

        // Make sure the file is created that we will be putting data into.
        public static void CreateProjectFile(string filepath)
        {
            if (File.Exists(filepath)) File.Delete(filepath);
            ZipFile.CreateFromDirectory(ProjectInfo.ProjectPath, filepath);
        }

        // obtained from a third party
        // obtained from http://stackoverflow.com/questions/5868790/saving-content-of-a-treeview-to-a-file-and-load-it-later
        // Saves the data of a Windows Forms TreeView object (serializes it).
        public static void SaveTree(TreeView tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
            }
        }

        // obtained from a third party
        // obtained from http://stackoverflow.com/questions/5868790/saving-content-of-a-treeview-to-a-file-and-load-it-later
        // Deserializes TreeView data to be put back into the form's control.
        public static void LoadTree(TreeView tree, string filename)
        {
            tree.Nodes.Clear();

            using (Stream file = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object obj = bf.Deserialize(file);

                TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
                tree.Nodes.AddRange(nodeList);
            }
        }

        // obtained from a third party
        // obtained from http://www.codeproject.com/Articles/14403/Generating-Unique-Keys-in-Net
        // Generates a unique file ID whenever needed, to allow for duplicate names. IDs will always be different.
        public static string GenerateUniqueID()
        {
            int maxSize = 8;
            //int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();
        }
    }
}
