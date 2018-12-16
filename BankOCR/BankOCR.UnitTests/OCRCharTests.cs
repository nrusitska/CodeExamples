using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankOCR.UnitTests
{
    [TestClass]
    public class OCRCharTests
    {
        [TestMethod]
        public void TestCharInterpretation()
        {
            TestSlice(new string[] { " _ ", "I I", "I_I" }, "0");
            TestSlice(new string[] { "   ", "  I", "  I" }, "1");
            TestSlice(new string[] { " _ ", " _I", "I_ " }, "2");
            TestSlice(new string[] { " _ ", " _I", " _I" }, "3");
            TestSlice(new string[] { "   ", "I_I", "  I" }, "4");
            TestSlice(new string[] { " _ ", "I_ ", " _I" }, "5");
            TestSlice(new string[] { " _ ", "I_ ", "I_I" }, "6");
            TestSlice(new string[] { " _ ", "  I", "  I" }, "7");
            TestSlice(new string[] { " _ ", "I_I", "I_I" }, "8");
            TestSlice(new string[] { " _ ", "I_I", " _I" }, "9");
        }

        private void TestSlice(string[] slice, string expectation)
        {
            var character = new OCRCharacter(slice);
            string result = OCRCharInterpreter.InterpreteChar(character);
            Assert.AreEqual(expectation, result);
        }
    }
}
