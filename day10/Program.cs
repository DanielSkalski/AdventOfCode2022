

var datafile = "data.txt";

int[] cycles = { 20, 60, 100, 140, 180, 220 };

var instructions = File.ReadAllLines(datafile);

var register = 1;
int cycle = 1;
var signalStrengths = new List<int>();

foreach(var instruction in instructions)
{
    if (cycles.Contains(cycle))
    {
        signalStrengths.Add(cycle * register);
    }

    var command = instruction.Split(" ");
    if (command[0] == "addx")
    {
        var value = Convert.ToInt32(command[1]);
        cycle++;
        if (cycles.Contains(cycle))
        {
            signalStrengths.Add(cycle * register);
        }
        register += value;
    }

    cycle++;
}

var result = signalStrengths.Sum();

Console.WriteLine(result);
