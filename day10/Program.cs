var datafile = "data.txt";

int[] newlinesCycles = { 40, 80, 120, 160, 200, 240 };

var instructions = File.ReadAllLines(datafile);

var register = 1;
int cycle = 0;

foreach(var instruction in instructions)
{
    if (newlinesCycles.Contains(cycle))
    {
        Console.WriteLine();
    }
    DrawPixel(cycle, register);

    var command = instruction.Split(" ");
    if (command[0] == "addx")
    {
        var value = Convert.ToInt32(command[1]);
        cycle++;

        if (newlinesCycles.Contains(cycle))
        {
            Console.WriteLine();
        }
        DrawPixel(cycle, register);

        register += value;
    }

    cycle++;
}

static void DrawPixel(int cycle, int register)
{
    var spritePosStart = register - 1;
    var spritePosEnd = register + 1;
    var drawnPos = cycle % 40;

    if (spritePosStart <= drawnPos && drawnPos <= spritePosEnd)
    {
        Console.Write("#");
    }
    else
    {
        Console.Write(".");
    }
}
