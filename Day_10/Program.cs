using System.Collections;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("Input.txt");
        //part 1
        string pipes = "-|FJ7L";
        char startingPoint = 'S';
        int rows = 0;
        int cols = 0;
        int result = 0;
        var lists = new List<List<char>>();     // for part 2
        int result2 = 0;                        
        for (int i = 0; i < input.Length; i++)  
        {                                       
            lists.Add(new List<char>());        
            for (int j = 0 ; j < input[i].Length ; j++)
            {                                   
                lists[i].Add(' ');              
            }                                   
        }                                     
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                if (input[i][j] == 'S')
                {
                    rows = i;
                    cols = j;
                    break;
                }
            }
        }
        char currentLocation = input[rows][cols];
        string pastLocation = "";
        do
        {   
            lists[rows][cols] = currentLocation; // for part 2
            if (CurrentCheck(currentLocation, pipes, startingPoint, 0, 3, 4) && 
                NextCheck(input, rows, cols - 1, pipes, 0, 2, 5, startingPoint) &&
                PastCheck(pastLocation, "left", ""))
            {
                currentLocation = input[rows][cols - 1]; // go left
                cols = cols - 1;
                result++;
                pastLocation = "right";
            }
            else if (CurrentCheck(currentLocation, pipes, startingPoint, 0, 2, 5) &&
                NextCheck(input, rows, cols + 1, pipes, 0, 3, 4, startingPoint) &&
                PastCheck(pastLocation, "right", ""))
            {
                currentLocation = input[rows][cols + 1]; // go right
                cols = cols + 1;
                result++;
                pastLocation = "left";
            }
            else if (CurrentCheck(currentLocation, pipes, startingPoint, 1, 3, 5) &&
                NextCheck(input, rows - 1, cols, pipes, 1, 2, 4, startingPoint) &&
                PastCheck(pastLocation, "up", ""))
            {
                currentLocation = input[rows - 1][cols]; // go up
                rows = rows - 1;
                result++;
                pastLocation = "down";
            }
            else if (CurrentCheck(currentLocation, pipes, startingPoint, 1, 2, 4) &&
                NextCheck(input, rows + 1, cols, pipes, 1, 3, 5, startingPoint) &&
                PastCheck(pastLocation, "down", ""))
            {
                currentLocation = input[rows + 1][cols]; //go down
                rows = rows + 1;
                result++;
                pastLocation = "up";
            }
        } while (currentLocation != 'S');
        Console.WriteLine(result / 2);
        // part 2
        for (int i = 0; i < lists.Count; i++)
        {
            for (int j = 0; j < lists[i].Count; j++)
            {
                char space = lists[i][j];
                if (space == ' ')
                {
                    int count = 0;
                    for (int k = i, l = j; k >= 0 && l >= 0; k--, l--)
                    {
                        char next = lists[k][l];
                        if (next == pipes[0] || next == pipes[1] || next == pipes[2] || next == pipes[3] || next == startingPoint)
                        {
                            count++;
                        }
                    }
                    if (count % 2 == 0)
                    {
                       lists[i][j] = '0';
                    }
                }

            }
        }
        foreach (var list in lists)
        {
            foreach (char c in list)
            {
                if(c == ' ')
                {
                    result2++;
                }
            }
        }
        Console.WriteLine(result2);
    }
    private static bool CurrentCheck(char ch, string pipes, char s,int num1, int num2, int num3)
    {
        if (ch == s || ch == pipes[num1] || ch == pipes[num2] || ch == pipes[num3])
        {
            return true;
        }
        return false;
    }
    private static bool NextCheck(string[] input, int rows, int cols, string pipes, int num1, int num2, int num3, char s)
    {
        if (input[rows][cols] == pipes[num1] || input[rows][cols] == pipes[num2] ||
            input[rows][cols] == pipes[num3] || input[rows][cols] == s) 
        { 
            return true;
        }
        return false;
    }
    private static bool PastCheck(string pastLocation, string direction, string start)
    {
        if (pastLocation == start || pastLocation != direction)
        {
            return true;
        }
        return false;
    }
}