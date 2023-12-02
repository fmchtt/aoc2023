namespace AdventOfCode.Days;

public class TwoPartTwo
{
    public void Execute()
    {
        var reader = new StreamReader(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Inputs", "DayTwoInput.txt"));
        
        var line = reader.ReadLine();
        var multipliedGames = new List<int>();
        while (line != null)
        {
            var split = line.Split(":");
            var gameNumber = Convert.ToInt32(split[0].Replace("Game ", string.Empty));
            var rounds = split[1].Split(";");
            
            Console.Write($"Game {gameNumber} -> ");
            
            var minimunLineBlocks = new Dictionary<string, int>
            {
                {"green", int.MinValue},
                {"red", int.MinValue},
                {"blue", int.MinValue}
            };

            foreach (var round in rounds)
            {
                var blocks = round.Split(",");
                foreach (var block in blocks)
                {
                    var part = block.Trim().Split(" ");
                    var number = Convert.ToInt32(part[0]);
                    var color = part[1];

                    if (number > minimunLineBlocks[color]) minimunLineBlocks[color] = number;
                }
            }

            var multiply = 1;
            foreach (var key in minimunLineBlocks.Keys)
            {
                multiply *= minimunLineBlocks[key];
            }
            
            Console.WriteLine($"Green: {minimunLineBlocks["green"]} Red: {minimunLineBlocks["red"]} Blue: {minimunLineBlocks["blue"]} = {multiply}");
            multipliedGames.Add(multiply);
            
            line = reader.ReadLine();
        }
        
        Console.WriteLine(multipliedGames.Sum());
    }
}