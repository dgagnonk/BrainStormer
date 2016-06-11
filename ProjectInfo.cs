using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace BrainStormerNoPlugins
{
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

