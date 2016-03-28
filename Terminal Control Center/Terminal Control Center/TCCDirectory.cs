using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class TCCDirectory //   going to replace strings in List<String> userDir in Program.cs
    { //                    will be able to hold 2 strings for 1 list instead of 2 lists, 1 string
        string name;
        string path;

        public TCCDirectory(string name, string path)
        {
            this.name = name;
            this.path = path;
        }

        public string getName()
        {
            return name;
        }

        public string getPath()
        {
            return path;
        }



    }
}
