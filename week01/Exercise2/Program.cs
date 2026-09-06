using System;


    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("What is your grade percentage?");
            string gpercent = Console.ReadLine();

            int xcent = int.Parse(gpercent);
            string lgrade = "";
            string sign = "";
            int remainder = xcent % 10;

        if (xcent >= 90)
        {
            lgrade = "A";

        }
        else if (xcent >= 80)
        {
            lgrade = "B";

            if (remainder >= 7)
            {
                sign = "+";
            }
            else if (remainder <= 3)
            {
                sign = "-";
            }
        }
        else if (xcent >= 70)
        {
            lgrade = "C";

            if (remainder >= 7)
            {
                sign = "+";
            }
            else if (remainder <= 3)
            {
                sign = "-";
            }
        }
        else if (xcent >= 60)
        {
            lgrade = "D";

            if (remainder >= 7)
            {
                sign = "+";
            }
            else if (remainder <= 3)
            {
                sign = "-";
            }
        }
            else
            {
                lgrade = "F";
            }

            Console.WriteLine($"Your grade is: {lgrade}{sign}");

             if (xcent >= 70)
            {
                Console.WriteLine("Congrats! You passed!");
            }
            else
            {
                Console.WriteLine("You can do it better on the next time!");
            }
        }
    }