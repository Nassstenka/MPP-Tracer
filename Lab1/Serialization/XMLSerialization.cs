using MyTracer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestApplication
{
    class XMLSerialization : ISerializer
    {
        public string serialize(TraceResult traceResult)
        {
            MemoryStream memoryStream = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(TraceResult));
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true, NewLineOnAttributes = true };
            using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
                serializer.WriteObject(xmlWriter, traceResult);
            string str = Encoding.Default.GetString(memoryStream.ToArray());
            return str;
        }
    }
}
