var datafile = "./data.txt";

int bonusScore(char opponent, char roundResult) 
{
    return (opponent, roundResult) switch
    {
        ('A', 'X') => 3,
        ('A', 'Y') => 1,
        ('A', 'Z') => 2,

        ('B', 'X') => 1,
        ('B', 'Y') => 2,
        ('B', 'Z') => 3,

        ('C', 'X') => 2,
        ('C', 'Y') => 3,
        ('C', 'Z') => 1,

        _ => 0
    };
};

int winLoseScore(char roundResult) 
{
    return roundResult switch
    {
        'X' => 0,
        'Y' => 3,
        'Z' => 6,
        _ => 0
    };
}

var totalScore = 0;

foreach(var line in await File.ReadAllLinesAsync(datafile))
{
    var opponentChoice = line[0];
    var roundResult = line[2];

    var roundScore = 
        bonusScore(opponentChoice, roundResult) +
        winLoseScore(roundResult);

    totalScore += roundScore;
}

Console.WriteLine(totalScore);