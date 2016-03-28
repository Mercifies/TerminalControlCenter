using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class UserDir
    {
        List<string> userDir;
        string input = "";

        public UserDir(List<String> userDir, string input)
        {
            this.userDir = userDir;
            this.input = input;
            
        }

        public void newDir()
        {
            // checks for invalid characters
            if (input.Contains("/") || input.Contains(".") || input.Contains(",") || input.Contains("+") || input.Contains("*") || input.Contains("\\") || input.Contains("]") || input.Contains("[") || input.Contains("{") || input.Contains("}") || input.Contains(";") || input.Contains("'") || input.Contains("\"") || input.Contains(":") || input.Contains("<") || input.Contains(">") || input.Contains("%"))
            {
                // should throw error to user about invalid characters
            }
            else
            {
                userDir.Add(input.Substring(4, input.Length - 4)); // properly selects @varName
            }
        }

        public string getDir()
        {
            return userDir[0];
        }


    }
}
