var datafile = "data.txt";

var input = File.ReadAllText(datafile);

for (int i = 0; i < input.Length - 14; i++)
{
    var marker = input.Substring(i, 14);

    var markerFound = true;
    for (int x = 0; markerFound && x < 13; x++)
    {
        for (int y = x + 1; y < 14; y++)
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
        Console.WriteLine(i + 14);
        break;
    }
}