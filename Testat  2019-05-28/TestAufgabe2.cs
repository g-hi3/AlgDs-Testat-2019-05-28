using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Project
{
    [TestClass]
    public class TestAufgabe2
    {
        [TestMethod]
        public void TestFibonacci()
        {
            Assert.AreEqual(1, SchemaDemo.Fibonacci(1));
            Assert.AreEqual(1, SchemaDemo.Fibonacci(2));
            Assert.AreEqual(2, SchemaDemo.Fibonacci(3));
            Assert.AreEqual(102334155, SchemaDemo.Fibonacci(40));
        }

        [TestMethod]
        public void TestFibonacciRecursive()
        {
            Assert.AreEqual(1, SchemaDemo.FibonacciRecursive(1));
            Assert.AreEqual(1, SchemaDemo.FibonacciRecursive(2));
            Assert.AreEqual(2, SchemaDemo.FibonacciRecursive(3));
            Assert.AreEqual(102334155, SchemaDemo.FibonacciRecursive(40));
        }

        [TestMethod]
        public void TestReverseRecursive()
        {
            Assert.AreEqual("SARG", Aufgabe1.ReverseRecursive("GRAS"));
            Assert.AreEqual("sugus", Aufgabe1.ReverseRecursive("sugus"));
        }
    }
}
