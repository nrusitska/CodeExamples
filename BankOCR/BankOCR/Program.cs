using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BankOCR.UnitTests")]

namespace BankOCR
{
    using System;
    using System.IO;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            foreach (string fileName in args)
            {
                try
                {
                    string[] decodedLines = OCRLineInterpreter.InterpreteFileLines(File.ReadAllLines(fileName));
                    Console.WriteLine(string.Join(Environment.NewLine, decodedLines));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
