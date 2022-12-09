var datafile = "data.txt";

var lines = File.ReadAllLines(datafile);
var height = lines.Length;
var witdth = lines[0].Length;

int[,] grid = new int[height,witdth];

var i = 0;
foreach(var line in lines)
{
    var j = 0;
    foreach(char c in line)
    {
        grid[i, j] = Convert.ToInt32(Char.GetNumericValue(c));
        j++;
    }
    i++;
}

var result = 0;

for (i = 1; i < height - 1; i++)
for (var j = 1; j < witdth - 1; j++)
{
    // check top
    var topIsVisible = true;
    for (var k = i - 1; k >= 0; k--)
    {
        if (grid[k, j] >= grid[i, j])
        {
            topIsVisible = false;
            break;
        }
    }

    // check bottom
    var bottomIsVisible = true;
    for (var k = i + 1; k < height; k++)
    {
        if (grid[k, j] >= grid[i, j])
        {
            bottomIsVisible = false;
            break;
        }
    }

    // check left
    var leftIsVisible = true;
    for (var k = j - 1; k >= 0; k--)
    {
        if (grid[i, k] >= grid[i, j])
        {
            leftIsVisible = false;
            break;
        }
    }

    // check right
    var rightIsVisible = true;
    for (var k = j + 1; k < witdth; k++)
    {
        if (grid[i, k] >= grid[i, j])
        {
            rightIsVisible = false;
            break;
        }
    }

    if (topIsVisible || bottomIsVisible || leftIsVisible || rightIsVisible)
    {
        // Console.WriteLine($"Visible: {i}, {j} : {grid[i, j]}");

        result++;
    }
}

result += (witdth * 2) + (height * 2) - 4;

Console.WriteLine(result);
