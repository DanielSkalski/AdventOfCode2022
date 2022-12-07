var datafile = "data.txt";

var file = File.ReadLines(datafile);

var structureInput = file.TakeWhile(x => !string.IsNullOrWhiteSpace(x)).ToList();
var moves = file.SkipWhile(x => !string.IsNullOrWhiteSpace(x)).Skip(1).ToList();

var howManyPiles = Convert.ToInt32(structureInput.Last().Trim().Split(' ').Last());

var structure = new List<List<string>>();
for (int i = 0; i < howManyPiles; i++)
{
    structure.Add(new List<string>());
}

foreach (var horizontalLine in structureInput.SkipLast(1))
{
    var crates = horizontalLine.Chunk(4).Select(x => new string(x)).ToArray();
    for (int i = 0; i < howManyPiles; i++)
    {
        if (string.IsNullOrWhiteSpace(crates[i]))
            continue;

        var crateLetter = crates[i].Trim(' ', '[', ']');
        structure[i].Add(crateLetter);
    }
}

foreach (var move in moves)
{
    var moveParsed = move.Split(' ');
    int howMany = Convert.ToInt32(moveParsed[1]);
    int from = Convert.ToInt32(moveParsed[3]) - 1;
    int to = Convert.ToInt32(moveParsed.Last()) - 1;

    var cratesToMove = structure[from].Take(howMany);
    structure[to].InsertRange(0, cratesToMove);
    structure[from].RemoveRange(0, howMany);
}

var result = structure.Aggregate("", (acc, val) => acc + val.First());

Console.WriteLine(result);
