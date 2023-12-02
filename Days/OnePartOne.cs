namespace AdventOfCode.Days;

public class OnePartOne
{
    public void Execute()
    {
        var reader = new StreamReader(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Inputs", "DayOneInput.txt"));

        var line = reader.ReadLine();
        var numbers = new List<int>();
        while (line != null)
        {
            var lineNumbers = new List<string>();
            foreach (var letter in line.ToCharArray())
            {
                if (char.IsNumber(letter))
                {
                    lineNumbers.Add(letter.ToString());
                }
            }

            if (lineNumbers.Count < 2)
            {
                lineNumbers.Add(lineNumbers.First());
            }
    
            Console.WriteLine($"{numbers.Count + 1} -> {lineNumbers.First()} + {lineNumbers.Last()} = {Convert.ToInt32(lineNumbers.First() + lineNumbers.Last())}");
            numbers.Add(Convert.ToInt32(lineNumbers.First() + lineNumbers.Last()));
    
            line = reader.ReadLine();
        }

        var numberSum = numbers.Sum();
        Console.WriteLine(numberSum);
    }
}