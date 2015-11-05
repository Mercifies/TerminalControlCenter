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
            Console.WriteLine("$NAME        - $ is used to represent a string variable.");
            Console.WriteLine("#NUMBER      - # is used to represent a numerical variable.");
            Console.WriteLine("EXIT         - used to exit the program.");
            Console.WriteLine("CLS          - used to clear the screen.");
            Console.WriteLine("OPEN DIR     - opens file explorer to select a directory.");
            Console.WriteLine("PING         - pings a specific IP address. Use -NUMBER to set packets sent.");
            Console.WriteLine("REPEAT       - repeats the last command executed.");
            Console.WriteLine("TEXTBLOCK    - used to add comments in a comment block.");



        }


    }
}
