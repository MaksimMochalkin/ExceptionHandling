namespace Task1
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                var word = Console.ReadLine();
                TakeFirstLatter(word);

                Console.WriteLine("Press Esc to exit or Enter to continue");
                cki = Console.ReadKey();

            } while (cki.Key != ConsoleKey.Escape);
        }

        private static void TakeFirstLatter(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                Console.WriteLine("The entered string cannot be empty");
                return;
            }

            if (word.Substring(0,1).Equals(" "))
            {
                Console.WriteLine("Space cannot be entered as the first character");
                return;
            }

            var firstLatter = word.Substring(0, word.Length - (word.Length - 1));

            Console.WriteLine(firstLatter);
        }
    }
}