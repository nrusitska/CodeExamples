using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace BankOCR.UnitTests
{
    [TestClass]
    public class OCRLineTransformationTests
    {
        [TestMethod]
        public void CreateLine()
        {
            string[] testData = new[] { " ", " ", " " };
            var line = new OCRLine(testData);

            CollectionAssert.AreEqual(testData, line.OriginalContent);
        }

        [TestMethod]
        public void CreatLineException()
        {
            Assert.ThrowsException<FormatException>(() => new OCRLine(new string[0]));
            Assert.ThrowsException<FormatException>(() => new OCRLine(new string[] { "", "" }));
            Assert.ThrowsException<FormatException>(() => new OCRLine(Enumerable.Empty<string>()));
            Assert.ThrowsException<FormatException>(() => new OCRLine(Enumerable.Repeat(" ", 4)));
            Assert.ThrowsException<FormatException>(() => new OCRLine(Enumerable.Repeat(" ", 6)));
        }

        [TestMethod]
        public void SplitLineException()
        {
            Assert.ThrowsException<FormatException>(
                () => OCRLineInterpreter.CreateOcrLines(new[] { "", "" }));

            Assert.ThrowsException<FormatException>(
                () => OCRLineInterpreter.CreateOcrLines(Enumerable.Repeat(" ", 5)));

            Assert.ThrowsException<FormatException>(
                () => OCRLineInterpreter.CreateOcrLines(Enumerable.Repeat(" ", 9)));

            Assert.ThrowsException<FormatException>(
                () => OCRLineInterpreter.CreateOcrLines(Enumerable.Repeat(" ", 14)));
        }

        [TestMethod]
        public void SplitLines()
        {
            string[] fileContent = File.ReadAllLines("TestFiles\\TwoLines.txt");
            OCRLine[] result = OCRLineInterpreter.CreateOcrLines(fileContent);

            Assert.AreEqual(2, result.Length);
        }

        [TestMethod]
        public void SplitMultipleLines()
        {
            OCRLine[] result = OCRLineInterpreter.CreateOcrLines(Enumerable.Repeat(" ", 3));
            Assert.AreEqual(1, result.Length);

            result = OCRLineInterpreter.CreateOcrLines(Enumerable.Repeat(" ", 7));
            Assert.AreEqual(2, result.Length);

            result = OCRLineInterpreter.CreateOcrLines(Enumerable.Repeat(" ", 11));
            Assert.AreEqual(3, result.Length);
        }
    }
}
