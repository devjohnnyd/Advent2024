using System.Text.RegularExpressions;

namespace Advent2024.Days
{
    public class Day3 : IAdventDay
    {
        public string SolvePart1(string input)
        {
            // Read the content of the file
            string fileInput = File.ReadAllText(input);

            // Define a regular expression to match valid mul(X,Y) instructions
            // X and Y should be 1-3 digit numbers
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            Regex regex = new Regex(pattern);

            int sum = 0;

            // Find matches in the input
            MatchCollection matches = regex.Matches(fileInput);

            foreach (Match match in matches)
            {
                // Extract the numbers X and Y
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                // Calculate the multiplication and add to the sum
                sum += x * y;
            }

            // Output the result
            return sum.ToString();
        }
        public string SolvePart2(string input)
        {
            try
            {
                // Read the content of the file
                string fileInput = File.ReadAllText(input);

                // Define regex pattern to capture all instructions
                string instructionPattern = @"(mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))";
                Regex instructionRegex = new Regex(instructionPattern);

                // Variables
                bool isEnabled = true; // Mul instructions start enabled
                int sum = 0;

                // Find all matches for instructions
                MatchCollection matches = instructionRegex.Matches(fileInput);

                // Process each match sequentially
                foreach (Match match in matches)
                {
                    string instruction = match.Value;

                    if (instruction == "do()")
                    {
                        // Enable mul instructions
                        isEnabled = true;
                    }
                    else if (instruction == "don't()")
                    {
                        // Disable mul instructions
                        isEnabled = false;
                    }
                    else if (instruction.StartsWith("mul("))
                    {
                        // Process mul(X,Y) if enabled
                        if (isEnabled)
                        {
                            // Extract numbers from the instruction
                            string[] numbers = instruction.Substring(4, instruction.Length - 5).Split(',');
                            int x = int.Parse(numbers[0]);
                            int y = int.Parse(numbers[1]);

                            // Add the result to the sum
                            sum += x * y;
                        }
                    }
                }

                // Return the result as a string
                return sum.ToString();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                return $"Error: {ex.Message}";
            }
        }
    }
}
