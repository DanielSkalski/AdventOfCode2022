
var filepath = "./data.txt";

var currentElf = 0;
var currentMax1 = 0;
var currentMax2 = 0;
var currentMax3 = 0;

foreach(var line in await File.ReadAllLinesAsync(filepath))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        if (currentElf > currentMax1)
        {
            currentMax3 = currentMax2;
            currentMax2 = currentMax1;
            currentMax1 = currentElf;
        }
        else if (currentElf > currentMax2)
        {
            currentMax3 = currentMax2;
            currentMax2 = currentElf;
        }
        else if (currentElf > currentMax3)
        {
            currentMax3 = currentElf;
        }
        currentElf = 0;
    }
    else
    {
        var calories = Convert.ToInt32(line);
        currentElf += calories;
    }
}

Console.WriteLine(currentMax1 + currentMax2 + currentMax3);