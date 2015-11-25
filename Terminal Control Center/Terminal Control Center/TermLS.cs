using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class TermLS
    {
        string input;
        string path;

        


        public TermLS(string input, string path)
        {
            this.input = input;
            this.path = path;
        }

        public void lsAll()
        {
            string[] dirs = Directory.GetDirectories(@path, "*");
            //DirectoryInfo[] dirsinfo = Directory.GetDirectories(@path, "*"); // gets dir info to see if folder is hidden
            string[] files = Directory.GetFiles(@path, "*");
            //FileInfo[] filesinfo = Directory.GetFiles(@path, "*"); // gets file info to see if file is hidden

            // lists folders in yellow
            foreach (string dir in dirs)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(dir + "\\");
            }


            // lists files in cyan
            foreach (string file in files)
            {
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(file);
            }

            Console.ForegroundColor = ConsoleColor.Green;


        } // public void lsAll()

        public void longList()
        {
            string name = input.Substring(3, input.Length);

            string[] dirs = Directory.GetDirectories(@path, "*");
            string[] files = Directory.GetFiles(@path, "*");

            foreach (string dir in dirs)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (dir.Contains(name))
                {
                    path += "\\" + name;
                    break;
                }
            }


            // lists files in cyan
            foreach (string file in files)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (file.Contains(name))
                {
                    path += "\\" + name;
                    break;
                }
            }

            //FileIOPermission fiop = new FileIOPermission(PermissionState as path);





        } // public void longList()

    }
}
