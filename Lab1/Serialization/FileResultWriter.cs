using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class FileResultWriter : IResultWriter
    {
        public void WriteResult(string result)
        {
            using (StreamWriter writer = new StreamWriter("test.txt", false, System.Text.Encoding.Default))
            {
                writer.WriteLine(result);
            }
        }
    }
}
