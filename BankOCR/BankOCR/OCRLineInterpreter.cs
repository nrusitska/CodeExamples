namespace BankOCR
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class OCRLineInterpreter
    {
        /// <summary>
        /// Takes a set of lines and groups them into <see cref="OCRLine"/> objects.
        /// Raised visiblility of internal for unit testing purposes.
        /// </summary>
        /// <param name="fileLines">single lines, content of a file</param>
        /// <returns>OCR lines</returns>
        internal static OCRLine[] CreateOcrLines(IEnumerable<string> fileLines)
        {
            int length = fileLines.Count();
            if ((length + 1) % 4 != 0)
            {
                throw new FormatException();
            }

            var lines = new List<OCRLine>(length / 3);
            while (fileLines.Any())
            {
                var line = new OCRLine(fileLines.Take(3));
                lines.Add(line);
                fileLines = fileLines.Skip(4);
            }

            return lines.ToArray();
        }

        internal static string[] InterpreteFileLines(IEnumerable<string> fileContent)
        {
            OCRLine[] ocrLines = CreateOcrLines(fileContent);
            return ocrLines.Select(InterpreteLine).ToArray();
        }

        internal static string InterpreteLine(OCRLine line)
        {
            try
            {
                IEnumerable<string> chars = line.GetChars().Select(OCRCharInterpreter.InterpreteChar);
                return chars.Aggregate((a, b) => a + b);
            }
            catch (FormatException)
            {
                return "invalid line";
            }
        }
    }
}
