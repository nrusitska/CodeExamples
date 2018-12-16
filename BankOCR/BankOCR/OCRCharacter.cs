namespace BankOCR
{
    using System;
    using System.Linq;

    internal class OCRCharacter
    {
        public OCRCharacter(string[] slice)
        {
            if (slice.Length != 3 || slice.Any(str => str.Length != 3))
            {
                throw new FormatException();
            }

            Content = slice;
        }

        public string[] Content { get; private set; }
    }
}
