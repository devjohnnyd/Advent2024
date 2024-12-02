using Advent2024;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter day number:");
        int dayNumber = int.Parse(Console.ReadLine());

        // Map day numbers to their respective input file paths
        var inputFiles = new Dictionary<int, string>
        {
            { 1, "C:\\Projects\\Advent2024\\puzzle-input\\Day1\\input.txt" },
            { 2, "C:\\Projects\\Advent2024\\puzzle-input\\Day2\\input.txt" },
            { 3, "C:\\Projects\\Advent2024\\puzzle-input\\Day3\\input.txt" },
            // Add more days as needed
        };

        if (!inputFiles.TryGetValue(dayNumber, out var inputFile))
        {
            Console.WriteLine($"No input file configured for Day {dayNumber}");
            return;
        }

        var day = DayFactory.GetDay(dayNumber);

        Console.WriteLine("Part 1:");
        Console.WriteLine(day.SolvePart1(inputFile));

        Console.WriteLine("Part 2:");
        Console.WriteLine(day.SolvePart2(inputFile));
    }
}
