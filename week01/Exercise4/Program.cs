using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
        
        int enteredNumber = -1;

        while (enteredNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string input = Console.ReadLine();
            enteredNumber = int.Parse(input);
            
            if (enteredNumber != 0)
            {
                numberList.Add(enteredNumber);
            }
        }

        int total = 0;

        foreach (int currentNumber in numberList)
        {
            total += currentNumber;
        }

        Console.WriteLine($"The sum is: {total}");

        float mean = ((float)total) / numberList.Count;

        Console.WriteLine($"The average is: {mean}");

        
        int largestNumber = numberList[0];

        foreach (int currentNumber in numberList)
        {
            if (currentNumber > largestNumber)
            {
                largestNumber = currentNumber;
            }
        }

        Console.WriteLine($"The max is: {largestNumber}");


        int smallestPositiveNumber = int.MaxValue;

        foreach (int currentNumber in numberList)
        {
            if (currentNumber > 0 && currentNumber < smallestPositiveNumber)
            {
                smallestPositiveNumber = currentNumber;
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");


        numberList.Sort();

        Console.WriteLine("The sorted list is:");

        foreach (int currentNumber in numberList)
        {
            Console.WriteLine(currentNumber);
        }
    }
}

