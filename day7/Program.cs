var datafile = "data.txt";

var directoriesLookup = new Dictionary<string, Directory>();

var homeDirectory = new Directory { ParentDir = null };
directoriesLookup.Add("/", homeDirectory);

Directory currentDirectory = homeDirectory;
var path = new [] { "/" };

foreach (var line in File.ReadAllLines(datafile))
{
    if (line.StartsWith("$"))
    {
        var command = line.Split(" ");
        if (command[1] == "cd")
        {
            if (command[2] == "..")
            {
                currentDirectory = currentDirectory.ParentDir ?? homeDirectory;
                path = currentDirectory == homeDirectory
                        ? new [] {"/" }
                        : path[..^1];
            }
            else if (command[2] == "/")
            {
                path = new [] {"/"};
                currentDirectory = homeDirectory;
            }
            else
            {
                path = path.Append(command[2]).ToArray();
                currentDirectory = directoriesLookup[Path.Join(path)];
            }
        }
    }
    else if (line.StartsWith("dir"))
    {
        var dirName = line.Split(" ")[1];
        var dirPath = Path.Join(path.Append(dirName).ToArray()); 
        if (!directoriesLookup.ContainsKey(dirPath))
        {
            directoriesLookup[dirPath] = new Directory { ParentDir = currentDirectory };
        }
    }
    else
    {
        var fileSize = Convert.ToInt64(line.Split(" ")[0]);
        currentDirectory.TotalSize += fileSize;
        var parentDir = currentDirectory.ParentDir;
        while (parentDir != null)
        {
            parentDir.TotalSize += fileSize;
            parentDir = parentDir.ParentDir;
        }
    }
}

var limit = 100000;
var dirsBelowLimit = directoriesLookup.Values.Where(x => x.TotalSize <= limit).ToArray();

var sum = dirsBelowLimit.Sum(x => x.TotalSize);

Console.WriteLine(sum);

class Directory
{
    public long TotalSize { get; set; } = 0;
    public required Directory? ParentDir { get; set; }
}



