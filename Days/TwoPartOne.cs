namespace AdventOfCode.Days;

public class TwoPartOne
{
    public void Execute()
    {
        var reader = new StreamReader(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Inputs", "DayTwoInput.txt"));
        
        var response = new Dictionary<string, int>
        {
            {"green", 13},
            {"red", 12},
            {"blue", 14}
        };
        var validGames = new List<int>();
        
        var line = reader.ReadLine();
        while (line != null)
        {
            var split = line.Split(":");
            var gameNumber = Convert.ToInt32(split[0].Replace("Game ", string.Empty));
            var rounds = split[1].Split(";");
            
            Console.Write($"Game {gameNumber} ");

            var valid = true;
            foreach (var round in rounds)
            {
                var roundBlocks = new Dictionary<string, int>
                {
                    {"green", 0},
                    {"red", 0},
                    {"blue", 0}
                };
                
                var blocks = round.Split(",");
                foreach (var block in blocks)
                {
                    var part = block.Trim().Split(" ");
                    var number = Convert.ToInt32(part[0]);
                    var color = part[1];

                    roundBlocks[color] += number;
                }

                valid = response.Keys.All(key => roundBlocks[key] <= response[key]);
                
                if (valid) continue;
                
                valid = false;
                
                break;
            }

            Console.WriteLine($"Valido: {valid}");
            if (valid)
            {
                validGames.Add(gameNumber);
            }

            line = reader.ReadLine();
        }
        
        Console.WriteLine(validGames.Sum());
    }
}