using System;

namespace BankOCR
{
    internal class OCRCharInterpreter
    {
        private static readonly string[] _numerals =
        {
            " _ "+
            "I I"+
            "I_I",

            "   "+
            "  I"+
            "  I",

            " _ "+
            " _I"+
            "I_ ",

            " _ "+
            " _I"+
            " _I",

            "   "+
            "I_I"+
            "  I",

            " _ "+
            "I_ "+
            " _I",

            " _ "+
            "I_ "+
            "I_I",

            " _ "+
            "  I"+
            "  I",

            " _ "+
            "I_I"+
            "I_I",

            " _ "+
            "I_I"+
            " _I",
        };

        internal static string InterpreteChar(OCRCharacter character)
        {
            string serialized = string.Join(string.Empty, character.Content);
            int index = Array.IndexOf(_numerals, serialized);

            if (index < 0 || index > 9)
            {
                throw new FormatException();
            }

            return index.ToString();
        }
    }
}
