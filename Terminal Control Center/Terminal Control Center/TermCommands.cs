using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class TermCommands
    {
        public TermCommands()
        {

        }

        public void getCommands()
        {
            Console.WriteLine("$NAME        - string variable");
            Console.WriteLine("#NUMBER      - #numerical variable");
            Console.WriteLine("EXIT         - exit the program");
            Console.WriteLine("CD           - change directory");
            Console.WriteLine("CLS          - clear screen");
            Console.WriteLine("MV           - move a file/folder");
            Console.WriteLine("OPEN DIR     - open file explorer to select a directory");
            Console.WriteLine("PING         - pings a specific IP address. Use -NUMBER to set packets sent");
            Console.WriteLine("REPEAT       - repeats the last command executed");
            Console.WriteLine("TEXTBLOCK    - add comments in a comment block");



        }


    }
}
