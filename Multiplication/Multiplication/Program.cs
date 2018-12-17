using System;

namespace Multiplication
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                Multiplicator.Mul(int.Parse(args[0]), int.Parse(args[1]));
            }
            catch
            {
                Console.WriteLine("pass two numbers as parameter");
            }
        }
    }
}
