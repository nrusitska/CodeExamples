namespace Multiplication
{
    public class Multiplicator
    {
        public static int Mul(int x, int y)
        {
            int result = 0;
            while (x >= 1)
            {
                if (x % 2 != 0)
                {
                    result += y;
                }

                x = x / 2;
                y = 2 * y;
            }

            return result;
        }
    }
}
