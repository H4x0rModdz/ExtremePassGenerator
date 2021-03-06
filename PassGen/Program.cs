using System;
using System.Threading;

namespace ExtremePassGenerator
{

    internal class Program
    {
        static bool upper, lower, number, special;
        static int PasswordLenght;
        static bool running = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Password Lenght: MIN 1 | MAX 50");
            PasswordLenght = Convert.ToInt32(Console.ReadLine());

            upper = lower = number = special = true;

            Console.Clear();
            while (running)
            {
                if (PasswordLenght <= 50)
                {
                    Console.WriteLine(PassGen.Password(
                                                       upper,
                                                       lower,
                                                       number,
                                                       special,
                                                       PasswordLenght));

                    
                    Console.WriteLine("New password in 5sec");
                    Console.WriteLine();
                    Thread.Sleep(5000);

                }
                else
                {
                    Console.WriteLine("Enter a valid number!");
                    Console.WriteLine("Closing...");
                }

            }
        }

        public static class PassGen
        {
            private static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            private static string Numbers = "1234567890";
            private static string Specials = "!@#$%&*()?^-çÇ";

            public static string Password(
                bool useUpper,
                bool useLower,
                bool useNumbers,
                bool useSpecials,
                int PasswordSize)
            {
                Random random = new Random();
                string charSet = string.Empty;
                char[] password = new char[PasswordSize];

                if (useUpper) charSet += Upper;
                if (useLower) charSet += Upper.ToLower();
                if (useNumbers) charSet += Numbers;
                if (useSpecials) charSet += Specials;

                for (int i = 0; i < PasswordSize; i++)
                {
                    password[i] = charSet[random.Next(charSet.Length - 1)];
                }

                return String.Join(null, password);
            }
        }
    }
}
