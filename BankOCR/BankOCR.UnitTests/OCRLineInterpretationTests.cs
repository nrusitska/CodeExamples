using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace BankOCR.UnitTests
{
    [TestClass]
    public class OCRLineInterpretationTests
    {
        [TestMethod]
        public void InterpreteBrokenFile()
        {
            string[] fileContent = File.ReadAllLines("TestFiles\\BrokenLine.txt");
            string[] interpretedLines = OCRLineInterpreter.InterpreteFileLines(fileContent);
            CollectionAssert.AreEqual(new[] { "1337", "invalid line", "42" }, interpretedLines);
        }

        [TestMethod]
        public void InterpreteRaggedFile()
        {
            string[] fileContent = File.ReadAllLines("TestFiles\\DifferentLengths.txt");
            string[] interpretedLines = OCRLineInterpreter.InterpreteFileLines(fileContent);
            CollectionAssert.AreEqual(new[] { "1337", "42" }, interpretedLines);
        }

        [TestMethod]
        public void InterpreteSymetricFile()
        {
            string[] fileContent = File.ReadAllLines("TestFiles\\TwoLines.txt");
            string[] interpretedLines = OCRLineInterpreter.InterpreteFileLines(fileContent);
            CollectionAssert.AreEqual(new[] { "88", "88" }, interpretedLines);
        }

        [TestMethod]
        public void InterpreteTornFile()
        {
            string[] fileContent = File.ReadAllLines("TestFiles\\TornLine.txt");
            string[] interpretedLines = OCRLineInterpreter.InterpreteFileLines(fileContent);
            CollectionAssert.AreEqual(new[] { "invalid line", "42" }, interpretedLines);
        }
    }
}
