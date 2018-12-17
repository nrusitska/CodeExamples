using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Multiplication.UnitTests
{
    [TestClass]
    public class MultiplicationTests
    {
        [TestMethod]
        public void Test_47_42()
        {
            TestMultiplication(47, 42);
        }

        [TestMethod]
        public void TestMultiplications()
        {
            TestMultiplication(72, 90);
            TestMultiplication(123, 321);
            TestMultiplication(123, 322);
            TestMultiplication(5000, 111);
        }

        [TestMethod]
        public void TestMultiplicationWithOne()
        {
            TestMultiplication(47, 1);
            TestMultiplication(1, 42);
        }

        private void TestMultiplication(int x, int y)
        {
            Assert.AreEqual(x * y, Multiplicator.Mul(x, y));
        }
    }
}
