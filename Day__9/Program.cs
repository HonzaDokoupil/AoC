using System.Collections.Generic;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("Input.txt");
        int result = 0;
        int result2 = 0;
        // part 1
        for (int i = 0; i < input.Length; i++)
        {
            string[] numbers = input[i].Split(' ');
            var list = new List<List<int>>();
            for (int j = 0;j < numbers.Length; j++)
            {
                list.Add(new List<int>());
            }
            for (int j = 0; j < numbers.Length; j++)
            {
                list[0].Add(int.Parse(numbers[j]));
            }
            int actual = 0;
            while (!Zeroes(list[actual]))
            {
                
                for (int n = 0;n < list[actual].Count - 1;n++)
                {
                    int num1 = list[actual][n];
                    int num2 = list[actual][n + 1];
                    list[actual + 1].Add(num2 - num1);
                }
                actual++;
            }
            list = list.Where(s => s.Count > 0).ToList();
            list[list.Count - 1].Add(0);
            for (int e = list.Count - 2; e >= 0; e--)
            {
                list[e].Add((list[e][list[e].Count - 1]) + (list[e + 1][list[e + 1].Count - 1]));
            }
            result += list[0][list[0].Count - 1];  
            // part 2
            foreach (var l in list)
            {
                l.Reverse();
            }
            for (int e = list.Count - 2; e >= 0; e--)
            {
                list[e].Add((list[e][list[e].Count - 1]) - (list[e + 1][list[e + 1].Count - 1]));
            }
            result2 += list[0][list[0].Count - 1];
        }
        Console.WriteLine(result);
        Console.WriteLine(result2);      
    }
    private static bool Zeroes(List<int> numbers) 
    {
         bool zeroes = true;
         for (int i = 0; i < numbers.Count; i++)
         {
            if (numbers[i] != 0)
            {
                    zeroes = false;
            }
         }
         return zeroes;
    }
}