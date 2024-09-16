using System.Text;

namespace RomanNumerals
{
    /// <summary>
    /// Roman Numerals example
    /// </summary>
    internal class Program
    {
        // Dictionary to hold roman numerals and int values    
        public static Dictionary<char, int> romanNumeralToArabic = new()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };
        // Priority order in descending order
        public static char[] romanNumeralPriorityOrder = ['M', 'D', 'C', 'L', 'X', 'V', 'I'];
        /// <summary>
        /// Roman Numberals example
        /// </summary>
        static void Main()
        {
            Console.WriteLine("ToLazy:");
            Console.WriteLine(ToLazy(4)); // 'IIII'
            Console.WriteLine(ToLazy(150)); // 'CL'
            Console.WriteLine(ToLazy(944)); // 'DCCCCXXXXIIII'
        }

        /// <summary>
        /// Takes a number and converts to a roman numeral
        /// This does not simplify the roman numeral
        /// </summary>
        /// <param name="number">number to convert</param>
        /// <returns>roman numeral result</returns>
        static StringBuilder ToLazy(int number)
        {
            // Use StringBuilder because we will continue to modify the string
            StringBuilder output = new("");
            // Iterate through our priority order
            foreach(char numeral in romanNumeralPriorityOrder)
            {
                // Calculate the divisor
                // cast into int for expected result
                int divisor = (int)MathF.Floor(number / romanNumeralToArabic[numeral]);
                // update the number
                number -= divisor * romanNumeralToArabic[numeral];
                // populate the string
                for(int index = 0; index < divisor; index++)
                {
                    output.Append(numeral);
                }
            }
            return output;
        }
    }
}
