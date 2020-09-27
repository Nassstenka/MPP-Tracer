using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    interface ISerializer
    {
        public string serialize(object obj);
    }
}
