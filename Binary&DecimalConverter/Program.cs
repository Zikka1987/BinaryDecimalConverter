using System;

namespace BinaryDecimalConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter numbers separated by dots
            Console.WriteLine("Enter numbers separated by dots (e.g., 10101010.11001100 or 170.204):");
            string input = Console.ReadLine();

            // Split the input string into groups using '.' as the separator
            string[] groups = input.Split('.');

            // Check if the input is valid (at least one group)
            if (groups.Length == 0)
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            // Determine if the input is binary by checking the first group
            bool isBinary = IsBinary(groups[0]);

            // Array to hold the converted groups
            string[] outputGroups = new string[groups.Length];

            // Iterate over each group to convert it
            for (int i = 0; i < groups.Length; i++)
            {
                string group = groups[i];

                if (isBinary)
                {
                    // Convert binary string to decimal integer
                    int decimalValue = BinaryStringToInt(group);
                    if (decimalValue == -1)
                    {
                        Console.WriteLine("Invalid binary number: " + group);
                        return;
                    }
                    // Store the decimal value as a string
                    outputGroups[i] = decimalValue.ToString();
                }
                else
                {
                    // Convert decimal string to integer
                    int decimalValue = StringToInt(group);
                    if (decimalValue == -1)
                    {
                        Console.WriteLine("Invalid decimal number: " + group);
                        return;
                    }
                    // Convert integer to binary string
                    string binaryString = IntToBinaryString(decimalValue);

                    // Pad the binary string with leading zeros to make it 8 bits
                    binaryString = PadLeft(binaryString, 8);

                    // Store the binary string
                    outputGroups[i] = binaryString;
                }
            }

            // Join the converted groups back into a single string separated by dots
            string output = string.Join(".", outputGroups);

            // Display the converted result
            Console.WriteLine("Converted result: " + output);
        }

        // Method to check if a string represents a binary number
        static bool IsBinary(string str)
        {
            foreach (char c in str)
            {
                // If the character is not '0' or '1', it's not binary
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }

        // Method to convert a binary string to a decimal integer
        static int BinaryStringToInt(string binaryString)
        {
            int result = 0;

            foreach (char c in binaryString)
            {
                if (c == '0')
                {
                    // Multiply the result by 2 for '0'
                    result = result * 2;
                }
                else if (c == '1')
                {
                    // Multiply the result by 2 and add 1 for '1'
                    result = result * 2 + 1;
                }
                else
                {
                    // Return -1 if an invalid character is found
                    return -1;
                }
            }
            return result;
        }

        // Method to convert a decimal integer to a binary string
        static string IntToBinaryString(int number)
        {
            if (number == 0)
                return "0";

            string result = "";

            while (number > 0)
            {
                // Get the remainder (0 or 1) when divided by 2
                int remainder = number % 2;

                // Prepend the remainder to the result string
                result = remainder.ToString() + result;

                // Divide the number by 2 for the next iteration
                number = number / 2;
            }
            return result;
        }

        // Method to convert a decimal string to an integer
        static int StringToInt(string str)
        {
            int result = 0;

            foreach (char c in str)
            {
                // Check if the character is a digit
                if (c >= '0' && c <= '9')
                {
                    // Multiply the result by 10 and add the digit value
                    result = result * 10 + (c - '0');
                }
                else
                {
                    // Return -1 if an invalid character is found
                    return -1;
                }
            }
            return result;
        }

        // Method to pad a string with leading zeros to reach a total width
        static string PadLeft(string str, int totalWidth)
        {
            while (str.Length < totalWidth)
            {
                // Add '0' to the beginning of the string
                str = '0' + str;
            }
            return str;
        }
    }
}
