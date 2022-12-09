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

var maxScore = 0;

for (i = 1; i < height - 1; i++)
for (var j = 1; j < witdth - 1; j++)
{
    // check top
    var topScore = 0;
    for (var k = i - 1; k >= 0; k--)
    {
        topScore++;

        if (grid[k, j] >= grid[i, j])
        {
            break;
        }
    }

    // check bottom
    var bottomScore = 0;
    for (var k = i + 1; k < height; k++)
    {
        bottomScore++;
        if (grid[k, j] >= grid[i, j])
        {
            break;
        }
    }

    // check left
    var leftScore = 0;
    for (var k = j - 1; k >= 0; k--)
    {
        leftScore++;
        if (grid[i, k] >= grid[i, j])
        {
            break;
        }
    }

    // check right
    var rightScore = 0;
    for (var k = j + 1; k < witdth; k++)
    {
        rightScore++;
        if (grid[i, k] >= grid[i, j])
        {
            break;
        }
    }

    var currentScore = topScore * bottomScore * leftScore * rightScore;

    if (currentScore > maxScore)
    {
        maxScore = currentScore;
    }
}

Console.WriteLine(maxScore);
