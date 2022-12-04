var datafile = "data.txt";

var result = 0;

foreach (var line in File.ReadAllLines(datafile))
{
    var elves = line.Split(",");
    var firstElfRange = elves[0].Split("-");
    var firstElfStart = Convert.ToInt32(firstElfRange[0]);
    var firstElfEnd = Convert.ToInt32(firstElfRange[1]);

    var secondElfRange = elves[1].Split("-");
    var secondElfStart = Convert.ToInt32(secondElfRange[0]);
    var secondElfEnd = Convert.ToInt32(secondElfRange[1]);

    if ((secondElfStart <= firstElfStart && firstElfStart <= secondElfEnd)
    ||
        (secondElfStart <= firstElfEnd && firstElfEnd <= secondElfEnd))
    {
        result++;
    }
    else if (
        (firstElfStart <= secondElfStart && secondElfStart <= firstElfEnd)
    ||
        (firstElfStart <= secondElfEnd && secondElfEnd <= firstElfEnd))
    {
        result++;
    }
}

Console.WriteLine(result);