var datafile = "./data.txt";

var prioritiesSum = 0;

foreach(var groupRucksacks in File.ReadAllLines(datafile).Chunk(3))
{
    var register = new bool[53];
    var register2 = new bool[53];

    foreach (char item in groupRucksacks[0])
    {
        var itemNumber = getItemPriority(item);
        register[itemNumber] = true;
    }

    foreach (char item in groupRucksacks[1])
    {
        var itemNumber = getItemPriority(item);
        if (register[itemNumber])
        {
            register2[itemNumber] = true;
        }
    }

    foreach (char item in groupRucksacks[2])
    {
        var itemNumber = getItemPriority(item);
        if (register2[itemNumber])
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
