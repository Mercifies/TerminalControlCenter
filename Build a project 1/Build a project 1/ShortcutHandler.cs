using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Build_a_project_1
{
    class ShortcutHandler
    {
        RichTextBox richTextBox1;
        string style = "";

        public ShortcutHandler(RichTextBox richTextBox1, string style)
        {
            this.richTextBox1 = richTextBox1;
            this.style = style;
        }

        public void process()
        {
            if (richTextBox1.SelectedText.Length >= 1)
            {

                if (style.Equals("bold")) // bold text
                {
                    if (!richTextBox1.SelectionFont.Bold)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                    }

                    else
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                    }
                }

                else if (style.Equals("italic")) // currently not working
                {
                    if (!richTextBox1.SelectionFont.Italic)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
                    }

                    else
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                    }
                }
                

            }
        }

    }
}
