using System;
using System.Linq;

namespace Helper
{
    public class Help
    {
        public static int Read(string message)
        {
        lAge:
            Console.Write(message);

            string input = Console.ReadLine();

            bool isOk = int.TryParse(input, out int z);

            if (!isOk)
            {
                goto lAge;
            }
            return z;
        }

        public static string ReadText(string message, int? minLength)
        {
        lStr:
            Console.Write(message);

            string input = Console.ReadLine();
            bool NoDigit = input.Any(char.IsDigit);

            if (NoDigit)
            {
                Console.WriteLine("Type in only letters!");
                goto lStr;
            }
            else if (minLength.HasValue && input.Length < minLength)
                goto lStr;

            return input;
        }

        public static string ReadTextWithLengthEqual(string message, int length)
        {
            if (length < 1)
                length = 1;

            lStr:
            Console.Write(message);

            string input = Console.ReadLine();

            if (input.Length != length)
                goto lStr;

            return input;
        }
    }
}

