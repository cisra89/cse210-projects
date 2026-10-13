using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }


public void DisplayScore()
{
    Console.WriteLine($"\nYour current score is: {_score}");
    Console.WriteLine($"Your current level is: {GetLevel()}");
}


    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        DisplayGoals();
        Console.Write("\nWhich goal did you accomplish? ");

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("This goal is already complete!");
            return;
        }

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points.");

        Console.WriteLine($"Your total score is {_score}.");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"SCORE|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals and score saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        List<Goal> loadedGoals = new List<Goal>();
        int loadedScore = 0;

        try
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts[0] == "SCORE")
                {
                    loadedScore = int.Parse(parts[1]);
                }
                else if (parts[0] == "SimpleGoal" && parts.Length == 5)
                {
                    loadedGoals.Add(new SimpleGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        bool.Parse(parts[4])));
                }
                else if (parts[0] == "EternalGoal" && parts.Length == 4)
                {
                    loadedGoals.Add(new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])));
                }
                else if (parts[0] == "ChecklistGoal" && parts.Length == 7)
                {
                    loadedGoals.Add(new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])));
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("The save file contains invalid data.");
            return;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The save file is incomplete.");
            return;
        }

        _goals = loadedGoals;
        _score = loadedScore;

        Console.WriteLine("Goals and score loaded successfully.");
    }

        public string GetLevel()
    {
        if (_score >= 5000)
        {
            return "Level 4 - Eternal Master";
        }
        else if (_score >= 2500)
        {
            return "Level 3 - Quest Champion";
        }
        else if (_score >= 1000)
        {
            return "Level 2 - Goal Seeker";
        }
        else
        {
            return "Level 1 - Beginner";
        }
    }
}



