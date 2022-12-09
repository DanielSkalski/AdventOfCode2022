var datafile = "data.txt";

var lines = File.ReadAllLines(datafile);

var positions = new List<string>() { "0,0" };

int[] knots_x = new int[10];
int[] knots_y = new int[10];

foreach(var line in lines)
{
    var command = line.Split(" ");
    var direction = command[0];
    var distance = Convert.ToInt32(command[1]);

    for (int i = 0; i < distance; i++)
    {
        switch(direction)
        {
            case "R": knots_x[0]++; break;
            case "L": knots_x[0]--; break;
            case "U": knots_y[0]++; break;
            case "D": knots_y[0]--; break;
        }

        for(int k = 1; k < 10; k++)
        {
            if (Math.Abs(knots_y[k] - knots_y[k-1]) > 1 ||
                Math.Abs(knots_x[k] - knots_x[k-1]) > 1)
            {
                knots_y[k] += Math.Sign(knots_y[k-1] - knots_y[k]);
                knots_x[k] += Math.Sign(knots_x[k-1] - knots_x[k]);
            }
        }

        positions.Add($"{knots_x[9]},{knots_y[9]}");
    }
}

var result = positions.Distinct().Count();

Console.WriteLine(result);
