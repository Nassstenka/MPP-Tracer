using System;
using System.Threading;
using MyTracer;

namespace TestApplication
{
    public class Program
    {
        public static Tracer tracer = new Tracer();
        public static void Main(string[] args)
        {
            string result; 

            Method1();
            Method2();
            Method3();

            Console.WriteLine("How do you want to serialize results?");
            Console.WriteLine("1 - JSON");
            Console.WriteLine("2 - XML");
            string howToSerialize = Console.ReadLine();
            if (howToSerialize.Equals("1"))
            {
                JSONSerialization serialization = new JSONSerialization();
                result = serialization.serialize(tracer.GetTraceResult());
            }
            else if (howToSerialize.Equals("2"))
            {
                XMLSerialization serialization = new XMLSerialization();
                result = serialization.serialize(tracer.GetTraceResult());
            }
            else return;

            Console.WriteLine("How do you want to write results?");
            Console.WriteLine("1 - console");
            Console.WriteLine("2 - file");
            string howToWrite = Console.ReadLine();
            if (howToWrite.Equals("1"))
            {
                ConsoleResultWriter writer = new ConsoleResultWriter();
                writer.WriteResult(result);
            }
            else if (howToWrite.Equals("2"))
            {
                FileResultWriter writer = new FileResultWriter();
                writer.WriteResult(result);
            }
            else return;

            Console.ReadLine();
            return;
        }

        public static void Method1()
        {
            tracer.StartTrace();
            Thread.Sleep(1212);
            tracer.StopTrace();
        }
        public static void Method2()
        {
            tracer.StartTrace();
            Thread.Sleep(1573);
            tracer.StopTrace();
        }
        public static void Method3()
        {
            tracer.StartTrace();
            Method4();
            tracer.StopTrace();
        }
        public static void Method4()
        {
            tracer.StartTrace();
            Thread.Sleep(5151);
            tracer.StopTrace();
        }
    }
}
