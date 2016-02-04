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


            while (!exit)
            {
                Console.Write(path + "> ");
                string input = Console.ReadLine();
                input = input.ToLower();
                try
                {
                    switch (input)
                    {
                        case "cls": // clear screen
                            Console.Clear();
                            break;

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
                    }


                    if (input.Contains("compress"))
                    {
                        CompressFile cf = new CompressFile(input);
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

                        if (input.Substring(0, 5).Equals("new $")) // new variable
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

                        else if (input.Substring(0, 8).Equals("new file")) // new file
                        {
                            Console.Write("File Name: ");
                            input = Console.ReadLine().ToLower();

                        } // end new file
                    }

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
                
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occured.");
                    Console.ForegroundColor = ConsoleColor.Green;
                }

            } // end while loop (end command prompt)


        }
    }
}
