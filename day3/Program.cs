var datafile = "./data.txt";

var prioritiesSum = 0;

foreach(var line in await File.ReadAllLinesAsync(datafile))
{
    var compartmentSize = line.Length / 2;
    var firstCompartment = line[..compartmentSize];
    var secondCompartment = line[compartmentSize..];

    var register = new bool[53];
    foreach (char item in firstCompartment)
    {
        var itemNumber = getItemPriority(item);
        register[itemNumber] = true;
    }

    foreach (char item in secondCompartment)
    {
        var itemNumber = getItemPriority(item);
        if (register[itemNumber])
        {
            prioritiesSum += itemNumber;
            break;
        }
    }
}

Console.WriteLine(prioritiesSum);

static int getItemPriority(char item) => 
    item switch
    {
        <= 'Z' => 52 - ('Z' - item),
        _ => 26 - ('z' - item)
    };
