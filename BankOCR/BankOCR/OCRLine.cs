namespace BankOCR
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a document line, consisting of three text lines
    /// </summary>
    internal class OCRLine
    {
        public OCRLine(IEnumerable<string> trippleLine)
        {
            string[] lines = trippleLine.ToArray();
            if (lines.Length != 3)
            {
                throw new FormatException();
            }

            OriginalContent = lines;
        }

        public string[] OriginalContent { get; private set; }

        public OCRCharacter[] GetChars()
        {
            int length = OriginalContent[0].Length;
            var list = new List<OCRCharacter>((length + 1) / 4);
            for (int i = 0; i < length; i += 4)
            {
                string[] slice = OriginalContent.Select(str => str.Substring(i, 3)).ToArray();
                var character = new OCRCharacter(slice);
                list.Add(character);
            }

            return list.ToArray();
        }
    }
}
