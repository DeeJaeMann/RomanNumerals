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

            Console.WriteLine("ToModern");
            Console.WriteLine(ToModern(ToLazy(4))); // 'IV'
            Console.WriteLine(ToModern(ToLazy(150))); // 'CL'
            Console.WriteLine(ToModern(ToLazy(944))); // 'CMXLIV'
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

        /// <summary>
        /// Converts the roman numeral to a modern roman numeral
        /// </summary>
        /// <param name="lazyNumeral">Lazy formatted roman numeral</param>
        /// <returns>modern formatted roman numeral</returns>
        static StringBuilder ToModern(StringBuilder lazyNumeral)
        {
            // Iterate through the priority order
            for(int index = 0; index < romanNumeralPriorityOrder.Length; index++)
            {
                // Count of numeral matches
                int numeralCount = 0;
                // Ensure we're not on 'M'
                // We will not convert multiple 'M' roman numerals
                if(index > 0)
                {
                    // Iterate through the lazyNumeral string to compare matches
                    foreach(char numeral in lazyNumeral.ToString())
                    {
                        // Check our match
                        if (romanNumeralPriorityOrder[index] == numeral)
                        {
                            numeralCount++;
                        }
                        // If we have 4 matches we need to convert
                        if (numeralCount > 3)
                        {
                            // Generate the string to locate for replacement
                            string patternToMatch = string.Concat(Enumerable.Repeat(romanNumeralPriorityOrder[index], numeralCount));
                            // Generate the string to use for replacement
                            string patternToUse = $"{romanNumeralPriorityOrder[index]}{romanNumeralPriorityOrder[index-1]}";
                            lazyNumeral.Replace(patternToMatch, patternToUse);
                            // Outlier patterns representing 90 and 900
                            // Patch solution
                            lazyNumeral.Replace("DCD", "CM");
                            lazyNumeral.Replace("XLX", "XC");
                            // No further processing is needed for this numeral
                            break;
                        }
                    }
                }
            }
            return lazyNumeral;
        }
    }
}
