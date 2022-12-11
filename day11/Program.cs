var datafile = "data.txt";

var roundsToCompute = 20;

var lines = File.ReadAllLines(datafile).Select(x => x.Trim()).ToArray();

var monkeys = ReadData(lines);

for (int i = 0; i < roundsToCompute; i++)
{
    foreach (var monkey in monkeys)
    {
        monkey.InspectedItemsCount += monkey.Items.Count;

        foreach (var item in monkey.Items)
        {
            var newWorryLevel = ComputeWorryLevel(item, monkey.IncreaseFn);
            var recipientMonkey = monkey.TestFn(newWorryLevel);
            monkeys[recipientMonkey].Items.Add(newWorryLevel);
        }

        monkey.Items = new List<int>();
    }
}

var result = monkeys.OrderByDescending(x => x.InspectedItemsCount)
        .Take(2)
        .Aggregate(1, (acc, item) => acc * item.InspectedItemsCount);

Console.WriteLine(result);


int ComputeWorryLevel(int oldWorryLevel, Func<int, int> increaseFn)
{
    var newWorryLevel = increaseFn(oldWorryLevel);
    newWorryLevel /= 3;

    return newWorryLevel;
}

List<Monkey> ReadData(string[] lines)
{
    var result = new List<Monkey>();

    foreach(var monkeyLines in lines.Chunk(7))
    {
        int testDivisableBy = GetLastInt(monkeyLines[3]);
        int testIfTrue = GetLastInt(monkeyLines[4]);
        int testIfFalse = GetLastInt(monkeyLines[5]);

        result.Add(new Monkey
        {
            Items = monkeyLines[1].Split(":")[1].Split(",").Select(x => Convert.ToInt32(x)).ToList(),
            IncreaseFn = CreateIncreaseFn(monkeyLines[2].Split(":")[1].Trim()),
            TestFn = CreateTestFn(testDivisableBy, testIfTrue, testIfFalse)
        });
    }

    return result;
}

int GetLastInt(string line)
{
    return Convert.ToInt32(line.Split(" ").Last());
}

Func<int, int> CreateIncreaseFn(string operationStr)
{
    var splitted = operationStr.Split(" ");

    var arg1Str = splitted[2];
    var arg2Str = splitted[4];
    var operation = splitted[3];

    return (int val) => {
        var arg1 = arg1Str == "old" ? val : Convert.ToInt32(arg1Str);
        var arg2 = arg2Str == "old" ? val : Convert.ToInt32(arg2Str);
        
        return operation switch
        {
            "+" => arg1 + arg2,
            "-" => arg1 - arg2,
            "*" => arg1 * arg2,
            _ => throw new ArgumentOutOfRangeException(nameof(operation))
        };
    };
}

Func<int, int> CreateTestFn(int divisableBy, int monkeyTrue, int monkeyFalse)
{
    return (val) => val % divisableBy == 0 ? monkeyTrue : monkeyFalse;
}

class Monkey
{
    public List<int> Items { get; set; }
    public Func<int, int> IncreaseFn { get; init; }
    public Func<int, int> TestFn { get; init; }
    public int InspectedItemsCount { get; set; } = 0;
}

