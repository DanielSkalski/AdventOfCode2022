var datafile = "data.txt";

var lines = File.ReadAllLines(datafile);

var positions = new List<string>() { "0,0" };

int head_x = 0, head_y = 0;
int tail_x = 0, tail_y = 0;

foreach(var line in lines)
{
    var command = line.Split(" ");
    var direction = command[0];
    var distance = Convert.ToInt32(command[1]);

    for (int i = 0; i < distance; i++)
    {
        switch(direction)
        {
            case "R": head_x++; break;
            case "L": head_x--; break;
            case "U": head_y++; break;
            case "D": head_y--; break;
        }

        if (Math.Abs(tail_y - head_y) > 1 ||
            Math.Abs(tail_x - head_x) > 1)
        {
            tail_y += Math.Sign(head_y - tail_y);
            tail_x += Math.Sign(head_x - tail_x);
        }

        positions.Add($"{tail_x},{tail_y}");
    }
}

var result = positions.Distinct().Count();

Console.WriteLine(result);
