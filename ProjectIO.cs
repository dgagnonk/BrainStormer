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
    public static class ProjectIO
    {

        public static void CreateProjectFile(string filepath)
        {
            if (File.Exists(filepath)) File.Delete(filepath);
            ZipFile.CreateFromDirectory(ProjectInfo.ProjectPath, filepath);
        }

        // obtained from http://stackoverflow.com/questions/5868790/saving-content-of-a-treeview-to-a-file-and-load-it-later
        public static void SaveTree(TreeView tree, string filename)
        {
            using (Stream file = File.Open(filename, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
            }
        }

        // obtained from http://stackoverflow.com/questions/5868790/saving-content-of-a-treeview-to-a-file-and-load-it-later
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

        // taken from http://www.codeproject.com/Articles/14403/Generating-Unique-Keys-in-Net
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
