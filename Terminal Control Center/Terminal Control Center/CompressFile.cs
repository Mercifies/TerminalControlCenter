using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace Terminal_Control_Center
{
    class CompressFile
    {
        string input = "";


        public CompressFile(string input)
        {
            this.input = input;
        }

        public void doCompression()
        {


            using (FileStream inputStream = new FileStream(@"C\testFolder\temp.txt", FileMode.Open, FileAccess.ReadWrite))
            {

                using (FileStream outputStream = new FileStream(@"C:\testFolder\temp.zip", FileMode.Create, FileAccess.ReadWrite))
                {


                    using (GZipStream gzip = new GZipStream(outputStream, CompressionLevel.Optimal))
                    {
                        inputStream.CopyTo(gzip);
                    }
                }

            }


        }

    }
}
