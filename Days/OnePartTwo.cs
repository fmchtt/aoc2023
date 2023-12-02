namespace AdventOfCode.Days;

public class OnePartTwo
{
    private readonly List<string> _extendedNumbers = new()
    {
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    };
    
    private string VerifyNext(string word)
    {
        while (word.Length > 0)
        {
            word = word[1..];
            if (_extendedNumbers.Any(x => x.StartsWith(word)))
            {
                break;
            }
        }

        return word;
    }
    
    public void Execute()
    {
        var reader = new StreamReader(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Inputs", "DayOneInput.txt"));

        var line = reader.ReadLine();
        var numbers = new List<int>();
        while (line != null)
        {
            var lineNumbers = new List<string>();
            var actualWord = string.Empty;
            foreach (var letter in line.ToCharArray())
            {
                if (char.IsNumber(letter))
                {
                    lineNumbers.Add(letter.ToString());
                    actualWord = string.Empty;
                }
                else
                {
                    actualWord += letter;
                    if (_extendedNumbers.Any(x => x.StartsWith(actualWord)))
                    {
                        var index = _extendedNumbers.FindIndex(x => x == actualWord);
                        if (index == -1)
                        {
                            continue;
                        }
                        lineNumbers.Add((index + 1).ToString());
                        actualWord = VerifyNext(actualWord);
                    }
                    else
                    {
                        actualWord = VerifyNext(actualWord);
                    }
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