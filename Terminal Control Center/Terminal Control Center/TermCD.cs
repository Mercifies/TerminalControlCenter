using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class TermCD
    {
        string input;
        string path;


        public TermCD(string input, string path)
        {
            this.input = input;
            this.path = path;

            
        }

        public string getCD()
        {
            string[] dirs = Directory.GetDirectories(@path, "*");

            foreach (string dir in dirs)
            {
                // doesn't work because dir is the full directory,
                // we need just the folder name
                if (input.Contains(dir))
                {
                    path += "/" + dir;
                }
            }


            return path;
        }

    }
}
