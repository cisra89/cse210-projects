using System;

class Program
{
    static void Main(string[] args)
    {
        // I created a small library of scriptures instead of using only
        // one scripture. The program randomly chooses a scripture each
        // time it starts. I also made the program choose only words that
        // have not already been hidden.

        Random random = new Random();

        Reference reference1 = new Reference("Proverbs", 3, 5, 6);
        string text1 = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";

        Reference reference2 = new Reference("John", 3, 16);
        string text2 = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life";

        Reference reference3 = new Reference("Philippians", 4, 13);
        string text3 = "I can do all things through Christ which strengtheneth me";

        Scripture[] scriptures =
        {
            new Scripture(reference1, text1),
            new Scripture(reference2, text2),
            new Scripture(reference3, text3)
        };

        int randomIndex = random.Next(scriptures.Length);

        Scripture scripture = scriptures[randomIndex];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}
