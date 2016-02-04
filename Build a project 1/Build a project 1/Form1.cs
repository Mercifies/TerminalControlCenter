using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Build_a_project_1
{
    public partial class Form1 : Form
    {
        string wordCount = "";
        string lineCount = "";


        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control == true && e.KeyCode == Keys.B) // shortcut key for bold
            {

                ShortcutHandler sch = new ShortcutHandler(richTextBox1, "bold");
                sch.process();
            }
            else if (e.Control == true && e.KeyCode == Keys.I) // shortcut key for italic
            {

                ShortcutHandler sch = new ShortcutHandler(richTextBox1, "italic");
                sch.process();
            }

        }
    }
}
