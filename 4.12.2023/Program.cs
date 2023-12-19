string[] input = File.ReadAllLines("input.txt");
int winningPoints = 0;
foreach (string line in input)
{
    string[] card = line.Split(':');
    string numbers = card[1];
    string[] numbersToArray = numbers.Split('|');
    string numbersLeft = numbersToArray[0];
    string numbersRight = numbersToArray[1];
    string[] numbersLA = numbersLeft.Split(" ",StringSplitOptions.RemoveEmptyEntries);
    string[] numbersRA = numbersRight.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int counter = 0;
    int cardPoints = 0;
    foreach (string number in numbersLA)
    {
        
        if (numbersRA.Contains(number))
        {
            if (counter == 0)
            {
                cardPoints += 1;
                counter++;
            }
            else
            {
                cardPoints *= 2;
            }                        
        }       
    }
    winningPoints += cardPoints;
}
Console.WriteLine(winningPoints);
// second part

int[] scratchcards = new int[input.Length];
for (int i = 0; i < scratchcards.Length; i++)
{
    scratchcards[i] = 1;
}
for (int i = 0; i < input.Length; i++)
{
	string[] card = input[i].Split(':');
	string numbers = card[1];
	string[] numbersToArray = numbers.Split('|');
	string numbersLeft = numbersToArray[0];
	string numbersRight = numbersToArray[1];
	string[] numbersLA = numbersLeft.Split(" ", StringSplitOptions.RemoveEmptyEntries);
	string[] numbersRA = numbersRight.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int counter = 1;
    for (int j = 0; j < numbersLA.Length; j++)
    {
        if (numbersRA.Contains(numbersLA[j]))
        {
            scratchcards[i + counter] = scratchcards[i + counter] + 1 * scratchcards[i];
            counter++;
        }
    }
}
int scratchcardsTotal = scratchcards.Sum();
Console.WriteLine(scratchcardsTotal);
