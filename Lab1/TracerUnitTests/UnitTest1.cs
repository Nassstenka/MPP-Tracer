using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTracer;
using System.Threading;

namespace TracerUnitTests
{
    [TestClass]
    public class MyUnitTest
    {
        private Tracer tracer;

        [TestInitialize]
        public void init()
        {
            tracer = new Tracer();
        }
        [TestMethod]
        public void TestMethod1()
        {
            tracer.StartTrace();
            Thread.Sleep(1500);
            tracer.StopTrace();
        }
        [TestMethod]
        public void TestMethod2()
        {
            TestMethod1();
            TestMethod3();
        }
        [TestMethod]
        public void TestMethod3()
        {
            tracer.StartTrace();
            TestMethod1();
            tracer.StopTrace();
        }
        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            tracer.StartTrace();
            Factorial(5);
            tracer.StopTrace();
        }
    }
}
