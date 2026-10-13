using System;


        // Creativity and exceeding requirements:
        // I added a level system based on the total points earned.
        // Users progress from Beginner to Goal Seeker, Quest Champion,
        // and Eternal Master as they accomplish their goals.
        // This provides an additional reward and encourages continued
        // progress toward their personal goals.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string filename = "goals.txt";

        // Creativity: The program provides three goal types, tracks
        // progress and bonus points, and saves the quest between sessions.

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== ETERNAL QUEST ===");
            Console.WriteLine("1. Display Score");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Goal Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayScore();
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    CreateGoal(manager);
                    break;

                case "4":
                    manager.RecordEvent();
                    break;

                case "5":
                    manager.SaveGoals(filename);
                    break;

                case "6":
                    manager.LoadGoals(filename);
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Goodbye! Keep working on your quest.");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a goal type: ");

        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for this goal: ");

        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Please enter a valid non-negative number.");
            return;
        }

        Goal goal;

        if (type == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            Console.Write("How many times must you complete this goal? ");

            if (!int.TryParse(Console.ReadLine(), out int target) ||
                target <= 0)
            {
                Console.WriteLine("The target must be greater than zero.");
                return;
            }

            Console.Write("Enter the completion bonus: ");

            if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
            {
                Console.WriteLine("Please enter a valid non-negative bonus.");
                return;
            }

            goal = new ChecklistGoal(
                name, description, points, target, bonus);
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    }
}
