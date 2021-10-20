namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            try
            {
                CheckString(stringValue);
                if (stringValue.Equals(int.MinValue.ToString()))
                {
                    return int.MinValue;
                }

                if (stringValue.Equals(int.MaxValue.ToString()))
                {
                    return int.MaxValue;
                }

                var intNumber = 0;

                if (stringValue[0] == '-' || stringValue[0] == '+')
                {
                    var isNegative = stringValue[0] == '-';
                    var trimValue = stringValue.Substring(1);
                    var preparedString = PrepareString(trimValue);
                    intNumber = ConvertToInt(preparedString);
                    if (isNegative)
                    {
                        intNumber = -intNumber;
                    }
                }
                else
                {
                    var preparedString = PrepareString(stringValue);
                    intNumber = ConvertToInt(preparedString);
                }

                CheckInt(intNumber);

                return intNumber;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private int ConvertToInt(string trimValue)
        {
            var chars = trimValue.ToCharArray();
            var listNumbers = chars.Select(item => item - '0').ToList();

            var increment = 0;
            var number = listNumbers.Sum(number => (int)(number * Math.Pow(10, listNumbers.Count - (++increment))));
            
            return number;
        }

        private string PrepareString(string stringValue)
        {
            var withoutSpace = stringValue.Replace(" ", "");
            var regex = new Regex(@"[\D]");
            var match = regex.Match(withoutSpace);
            if (match.Length != 0)
            {
                throw new FormatException("String contains invalid characters.");
            }

            return withoutSpace;
        }

        private void CheckString(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(stringValue, "Value cannot be null or white space.");

            }

            if (stringValue == string.Empty || string.IsNullOrWhiteSpace(stringValue))
            {
                throw new FormatException("String contains invalid characters.");
            }
        }

        private void CheckInt(int intNumber)
        {
            if (intNumber > int.MaxValue || intNumber < int.MinValue)
            {
                throw new OverflowException("Number exceeds the range of valid values for Int.");
            }
        }
    }
}