var datafile = "data.txt";

var input = File.ReadAllText(datafile);

for (int i = 0; i < input.Length - 4; i++)
{
    var marker = input.Substring(i, 4);

    var markerFound = true;
    for (int x = 0; markerFound && x < 3; x++)
    {
        for (int y = x + 1; y < 4; y++)
        {
            if (marker[x] == marker[y])
            {
                markerFound = false;
                break;
            }
        }
    }

    if (markerFound)
    {
        Console.WriteLine(i + 4);
        break;
    }
}