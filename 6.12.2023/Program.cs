var input = File.ReadAllLines("input.txt");
var raceTimes = input[0].Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
var raceDistances = input[1].Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
int numberOfWays = 1;
for (int i = 1; i < raceTimes.Length; i++)
{
	int actualWays = 0;
	int time = int.Parse(raceTimes[i]);
	int distance = int.Parse(raceDistances[i]);
	for (int j = 0; j < time; j++)
	{
		if (j * (time - j) > distance)
		{
			actualWays++;
		}
	}
	numberOfWays *= actualWays;
}
Console.WriteLine(numberOfWays);
// part 2
long raceTime = long.Parse(string.Join("", raceTimes.Skip(1)));
long raceDistance = long.Parse(string.Join("", raceDistances.Skip(1)));
long ways = 0;
for (int i = 0;i < raceTime; i++)
{
	if (i * (raceTime - i) > raceDistance)
	{
		ways++;
	}
}
Console.WriteLine(ways);