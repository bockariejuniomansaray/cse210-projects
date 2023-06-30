using System;
using System.Collections.Generic;

// Base class for different types of goals
public abstract class Goal
{
    protected string name;
    protected int value;
    protected bool completed;

    public abstract void RecordEvent();
    public abstract string GetProgress();

    // Other shared attributes and behaviors can be added here
}

// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        this.name = name;
        this.value = value;
        this.completed = false;
    }

    public override void RecordEvent()
    {
        completed = true;
    }

    public override string GetProgress()
    {
        return completed ? "[X]" : "[ ]";
    }
}

// Eternal goal that can never be completed
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        this.name = name;
        this.value = value;
        this.completed = false;
    }

    public override void RecordEvent()
    {
        // For an eternal goal, always add the value when recorded
        // No need to check for completion
    }

    public override string GetProgress()
    {
        return completed ? "[X]" : "[ ]";
    }
}

// Checklist goal that must be accomplished a certain number of times to be complete
public class ChecklistGoal : Goal
{
    private int targetTimes;
    private int completedTimes;

    public ChecklistGoal(string name, int value, int targetTimes)
    {
        this.name = name;
        this.value = value;
        this.targetTimes = targetTimes;
        this.completedTimes = 0;
    }

    public override void RecordEvent()
    {
        completedTimes++;
        if (completedTimes >= targetTimes)
            completed = true;
    }

    public override string GetProgress()
    {
        return $"Completed {completedTimes}/{targetTimes} times";
    }
}

public class EternalQuestProgram
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.RecordEvent();
            totalScore += goal.value;
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].name} {goals[i].GetProgress()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }

    // Other methods for saving and loading goals can be added here
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        EternalQuestProgram questProgram = new EternalQuestProgram();
        questProgram.AddGoal(new SimpleGoal("Run a marathon", 1000));
        questProgram.AddGoal(new EternalGoal("Read scriptures", 100));
        questProgram.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

        questProgram.ShowGoals();
        questProgram.RecordEvent(0);
        questProgram.RecordEvent(1);
        questProgram.RecordEvent(2);
        questProgram.RecordEvent(2);
        questProgram.RecordEvent(2);
        questProgram.ShowGoals();
        questProgram.ShowScore();

        // Additional interactions and user input handling can be added here
    }
}
