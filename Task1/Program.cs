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
                try
                {
                    var word = Console.ReadLine();
                    var result = GetFirstLatter(word);
                    Console.WriteLine(result);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
                Console.WriteLine("Press Esc to exit or Enter to continue");
                cki = Console.ReadKey();

            } while (cki.Key != ConsoleKey.Escape);
        }

        private static string GetFirstLatter(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException(nameof(word), "Value can not be null.");
            }

            if (word.Substring(0,1).Equals(" "))
            {
                throw new FormatException($"Incorrect string format. You cannot put a space as the first character {nameof(word)}.");
            }

            return word.Substring(0, word.Length - (word.Length - 1));
        }
    }
}