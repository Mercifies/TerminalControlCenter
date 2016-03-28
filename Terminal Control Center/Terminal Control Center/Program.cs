using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string tempInput = "";
            bool done = false;
            bool exit = false;
            List<String> str = new List<String>(); // holds string variables
            List<String> repeat = new List<String>(); // holds last input for repeat function
            Console.Title = "Terminal Control Center";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BufferHeight = Int16.MaxValue - 1; // allows for maximum scrolling ability

            Stack<String> inputBreakup = new Stack<string>(); // stack to break up input into multiple

            List<String> userStrings = new List<string>(); // holds user's strings  $example
            List<String> userDir = new List<string>(); // holds user's directories  @example
            List<Double> userNum = new List<double>(); // holds user's nums         #example

            TermHelp help = new TermHelp();


            //
            //
            // start of actual handling
            //
            //
            while (!exit)
            {
                Console.Write(path + "> ");
                string input = Console.ReadLine();
                input = input.ToLower();

                Stack<int> lastInputIndex = new Stack<int>(); // holds y index for substring(x, y) of multiple command selection
                lastInputIndex.Push(input.Length - 1);

                // have to push backwards so first command is at top of list
                //
                //
                // not working
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (input[i].ToString().Equals("|")) // checks for pipes
                    {
                        inputBreakup.Push(input.Substring(input[i + 2], input[i + 2] - lastInputIndex.Pop())); // boken
                        lastInputIndex.Push(input[i] - 2); // index of | - 2, (ex: ls -a | print blah blah) <--- index of a
                    }

                    else if (input[i].ToString().Equals(";")) // checks for multiple commands same line
                    {
                        inputBreakup.Push(input.Substring(input[i + 1], lastInputIndex.Pop() - input[i + 1])); // broken
                        lastInputIndex.Push(input[i] - 1); // index of ; - 1, (ex: ls -a; print blah blah) <--- index of a
                    }
                    else if (i == 0 && inputBreakup.Count < 1) // no pipes, single command
                    {
                        inputBreakup.Push(input); // currently works
                    }
                }


                while (inputBreakup.Count >= 1) // main control
                {
                    input = inputBreakup.Pop(); // pops current command


                    try
                    {
                        switch (input)
                        {

                            case "textblock": // text block -- to write a bunch of text without triggering commands
                                while (!done)
                                {
                                    string text = Console.ReadLine();
                                    if (text.ToLower().Equals("</textblock>") || text.ToLower().Equals("<!"))
                                        done = true;
                                }
                                done = false;
                                break;

                            case "repeat": // repeats last command
                                if (repeat.Count > 0)
                                {
                                    input = repeat[repeat.Count - 1];
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: There is no command to repeat!");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                break;

                            case "commands": // lists commands
                                TermCommands tc = new TermCommands();
                                tc.getCommands();
                                break;


                            case "open dir":


                                break;

                            case "history":
                                for (int i = 0; i < repeat.Count(); i++)
                                {
                                    Console.WriteLine("[" + (i + 1) + "]: " + repeat[i].ToString());
                                }

                                break;


                        }

                        // 11/6/15 - Mercifies
                        // change directory command
                        // currently broken
                        if (input.Substring(0, 2).Equals("cd"))
                        {

                            try
                            {
                                TermCD cd = new TermCD(input, path);
                                path = cd.getCD();
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.ToString());
                            }


                        }


                        // 11/6/15 - Mercifies
                        // shortcut for cd ../
                        if (input.Equals("../"))
                        {
                            try
                            {
                                path = path.Substring(0, path.LastIndexOf('\\'));
                            }
                            catch (ArgumentOutOfRangeException e) // outofbounds exception: c:\ has no parent folder
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Directory out of bounds exception. There is no parent folder available.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            catch (Exception e)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + e.ToString());
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }

                        if (input.Equals("cls") || input.Equals("clear")) // clear screen
                        {
                            Console.Clear();
                        }

                        if (input.Substring(0, 1).Equals("@")) // checks for userDir
                        {

                        }


                        if (input.Contains("copy"))
                        {
                            if (input.Contains("copy file"))
                            {
                                List<int> cp = new List<int>();

                                for (int i = 0; i < input.Length; i++)
                                {
                                    if (input[i].Equals('\"') || input[i].Equals('\"'))
                                    {
                                        cp.Add((i));
                                    }
                                }

                                tempInput = input.Substring(cp[0], cp[1]);

                                Console.WriteLine(tempInput);
                            }


                            //if (input.Substring(0, 12).Equals("copy file \""))
                            //{
                            //    tempInput = input.Substring(11, input.LastIndexOf("\""));
                            //    Console.WriteLine(tempInput);
                            //}
                            //Console.WriteLine(tempInput);

                        } // end input.Contains("copy")


                        if (input.Contains("compress"))
                        {
                            CompressFile cf = new CompressFile(input);
                        }

                        if (input.Substring(0, 4).Contains("help"))
                        {
                            help.getCommand(input);
                        }




                        // 11/6/15 - Mercifies
                        // Listing all files/folders
                        if (input.Equals("ls -a"))
                        {
                            TermLS tls = new TermLS(input, path);
                            tls.lsAll();
                        }

                        else if (input.Contains("ls"))
                        {

                        }


                        if (input.Contains("new")) // new object/variable/file
                        {

                            if (input.Substring(0, 5).Equals("new $")) // new string for userString
                            {
                                str.Add(input.Substring(5));

                                for (int i = 0; i < str.Count; i++)
                                {
                                    if (input.Substring(5).Equals(str[i].ToString()))
                                    {
                                        Console.WriteLine("$" + str[i] + " variable created successfully!");
                                    }
                                }

                            } // end new variable

                            else if (input.Substring(0, 5).Equals("new @")) // new directory for userDir
                            {
                                try
                                {
                                    UserDir ud = new UserDir(userDir, input);
                                    ud.newDir();
                                    Console.WriteLine(ud.getDir());
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.ToString());
                                }
                            } // end new @

                            else if (input.Substring(0, 5).Equals("new #")) // new number for userNum
                            {

                            } // end new #

                            else if (input.Substring(0, 8).Equals("new file")) // new file
                            {
                                Console.Write("File Name: ");
                                input = Console.ReadLine().ToLower();

                            } // end new file
                        } // end input.Contains("new")

                        if (input.Contains("ping")) // ping ip address
                        {
                            try
                            {
                                TermPing tp = new TermPing(input);
                                tp.getPing();
                            }



                            catch (Exception e)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: " + e.ToString());
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                        } // end ping

                        if (input.Contains("$")) // handles strings/variables
                        {


                        } // end $

                        if (input.Equals("exit")) // exits program
                            exit = true;



                        repeat.Add(input);

                    } // try
                    catch
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error has occured.");
                        Console.ForegroundColor = ConsoleColor.Green;

                    } // catch

                } // while (inputBreakup.Count >= 1)

            } // while (!exit)


        }
    }
}
