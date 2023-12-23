using System.Runtime.Intrinsics.X86;

string[] input = File.ReadAllLines("Input.txt");
string instuction = input[0];
var locations = new List<string>();
var lefts = new List<string>();
var rights = new List<string>();
for (int i = 2; i < input.Length; i++)
{
    input[i] = input[i].Replace("=", " ")
                       .Replace(",", " ")
                       .Replace("(", " ")
                       .Replace(")", " ");
    var inputs = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    locations.Add(inputs[0]);
    lefts.Add(inputs[1]);
    rights.Add(inputs[2]);
}
int actual = locations.IndexOf("AAA");
int steps = 0;
int counter = 0;
while (actual != locations.IndexOf("ZZZ"))
{
    if (instuction[counter] == 'L')
    {
        actual = locations.IndexOf(lefts[actual]);       
    }
    else if (instuction[counter] == 'R')
    {
        actual = locations.IndexOf(rights[actual]);
    }
    steps++;
    counter++;
    if (counter == instuction.Length)
    {
        counter = 0;
    }
}
Console.WriteLine(steps);
// part 2
var multipleActual = new List<int>();
foreach (var location in locations)
{
    if (location.EndsWith('A'))
    {
        multipleActual.Add(locations.IndexOf(location));
    }
}
// lets find LCM = least common multiple
var ghostsSteps = new List<int>();
for (int i = 0; i < multipleActual.Count(); i++)
{   
    int counter2 = 0;
    int oneGhostSteps = 0;
    while (!locations[multipleActual[i]].EndsWith('Z'))
    {
        if (instuction[counter2] == 'L')
        {
            multipleActual[i] = locations.IndexOf(lefts[multipleActual[i]]);
        }
        else if (instuction[counter2] == 'R')
        {
            multipleActual[i] = locations.IndexOf(rights[multipleActual[i]]);
        }
        counter2++;
        oneGhostSteps++;        
        if (counter2 == instuction.Length)
        {
            counter2 = 0;
        }
    }
    ghostsSteps.Add(oneGhostSteps);
}
for (int i = 0;i < ghostsSteps.Count(); i++)
{
    ghostsSteps[i] /= instuction.Length;
}
long stepsTotal = instuction.Length;
foreach (int ghostSteps in ghostsSteps)
{
    stepsTotal *= ghostSteps;
}
Console.WriteLine(stepsTotal);