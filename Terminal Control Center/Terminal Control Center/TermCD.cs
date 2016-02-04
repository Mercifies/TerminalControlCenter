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




            #region Shortcuts

            if (input.Equals("cd %appdata%")) // Appdata shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }

            else if (input.Equals("cd %cache%")) // cache folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            }

            else if (input.Equals("cd %cookies%")) // Cookies shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            }

            else if (input.Equals("cd %computer%") || input.Equals("cd %pc%") || input.Equals("cd %comp%")) // Computer shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            }

            else if (input.Equals("cd %desktop%") || input.Equals("cd %desk%")) // Desktop shortcut
            {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            else if (input.Equals("cd %documents%") || input.Equals("cd %doc%")) // documents folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            else if (input.Equals("cd %favorites%") || input.Equals("cd %fav%")) // Favorites folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            }

            else if (input.Equals("cd %localappdata%") || input.Equals("cd %lad%")) // Local appdata shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }

            else if (input.Equals("cd %music%") || input.Equals("cd %mus%")) // Music folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }

            else if (input.Equals("cd %pictures%") || input.Equals("cd %pic%")) // Pictures folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            else if (input.Equals("cd %programfiles%") || input.Equals("cd %pf%")) // ProgramFiles shortcut
            {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }

            else if (input.Equals("cd %programfilesx86%") || input.Equals("cd %pf86%")) // ProgramFiles x86 shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }

            else if (input.Equals("cd %startmenu%") || input.Equals("cd %sm%")) // Startmenu folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            }

            else if (input.Equals("cd %startup%") || input.Equals("cd %su%")) // Startup folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            }

            else if (input.Equals("cd %system32%") || input.Equals("cd %sys32%")) // System32 shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            }

            else if (input.Equals("cd %syswow64%") || input.Equals("cd %sys64%")) // SysWOW64 shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            }

            else if (input.Equals("cd %user%")) // User shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            else if (input.Equals("cd %videos%") || input.Equals("cd %vid%")) // Videos folder shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            }

            else if (input.Equals("cd %windows%") || input.Equals("cd %win%")) // WINDOWS shortcut
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            }

            

            

            

            






            #endregion


            else
            {
                foreach (string dir in dirs)
                {
                    // doesn't work because dir is the full directory,
                    // we need just the folder name
                    if (input.Contains(dir.Substring(dir.LastIndexOf('\\'), dir.Length - 1)))
                    {
                        path += "\\" + dir;
                    }
                }

            }

            return path;
        }

    }
}
