using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class TermHelp
    {

        public TermHelp()
        {

        }

        public void getCommand(string input)
        {
            if (input.Equals("help"))
            {

            }

            else if (input.Equals("help cd"))
            {
                cd();
            }

            else if (input.Contains("help new"))
            {
                if (input.Equals("help new"))
                {

                }
            }

            else if (input.Equals("help @"))
            {

            }

            else if (input.Equals("help ping"))
            {

            }
        }

        public void help()
        {
            Console.Clear();
            Console.WriteLine("Command: help");
            Console.WriteLine();
            Console.WriteLine("Description: Used to get help with commands, variables, and syntax.");
            Console.WriteLine();
            Console.WriteLine("Syntax:");
            Console.WriteLine("");
        }

        public void cd() // cd command
        {
            Console.Clear();
            Console.WriteLine("Command: cd");
            Console.WriteLine();
            Console.WriteLine("Description: Used to change the current active directory ($DIR) of the terminal");
            Console.WriteLine();
            Console.WriteLine("Syntax:");
            Console.WriteLine("");
            Console.WriteLine("     cd %appdata%                -   C:\\Users\\%USER%\\AppData\\Roaming\\");
            Console.WriteLine("");
            Console.WriteLine("     cd %cache%                  -   C:\\Users\\%USER%\\AppData\\Local\\Microsoft\\Windows\\INetCache\\");
            Console.WriteLine("");
            Console.WriteLine("     cd %cookies%                -   C:\\Users\\%USER%\\AppData\\Local\\Microsoft\\Windows\\INetCookies\\");
            Console.WriteLine("");
            Console.WriteLine("     cd %desktop%                -   C:\\Users\\%USER%\\Desktop\\");
            Console.WriteLine("     cd %desk%");
            Console.WriteLine("");
            Console.WriteLine("     cd %documents%              -   C:\\Users\\%USER%\\Documents\\");
            Console.WriteLine("     cd %doc%");
            Console.WriteLine("");
            Console.WriteLine("     cd %favorites%              -   C:\\Users\\%USER%\\Favorites\\");
            Console.WriteLine("     cd %fav%");
            Console.WriteLine("");
            Console.WriteLine("     cd %localappdata%           -   C:\\Users\\%USER%\\AppData\\Local\\");
            Console.WriteLine("     cd %lad%");
            Console.WriteLine("");
            Console.WriteLine("     cd %music%                  -   C:\\Users\\%USER%\\Music\\");
            Console.WriteLine("     cd %mus%");
            Console.WriteLine("");
            Console.WriteLine("     cd %pictures%               -   C:\\Users\\%USER%\\Pictures\\");
            Console.WriteLine("     cd %pic%");
            Console.WriteLine("");
            Console.WriteLine("     cd %programfiles%           -   C:\\Program Files\\");
            Console.WriteLine("     cd %pf%");
            Console.WriteLine("");
            Console.WriteLine("     cd %programfilesx86%        -   C:\\Program Files (x86)\\");
            Console.WriteLine("     cd %pf86%");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %startmenu%              -   C:\\Users\\%USER%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\");
            Console.WriteLine("     cd %sm%");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %startup%                -   C:\\Users\\%USER%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\");
            Console.WriteLine("     cd %su%");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %system32%               -   C:\\WINDOWS\\system32\\");
            Console.WriteLine("     cd %sys32%");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %syswow64%               -   C:\\WINDOWS\\SysWOW64\\");
            Console.WriteLine("     cd %sys64%");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %user%                   -   C:\\Users\\%USER%\\");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %videos%                 -   C:\\Users\\%USER%\\Videos\\");
            Console.WriteLine("     cd %vid%");
            Console.WriteLine("     ");
            Console.WriteLine("     cd %windows%                -   C:\\WINDOWS\\");
            Console.WriteLine("     cd %win%");

        }



    }
}
