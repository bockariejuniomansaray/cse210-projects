using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    protected MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    public abstract void Start();
    public abstract void End();
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine();

        Console.WriteLine($"Set the duration for this activity (in seconds): {duration}");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        for (int i = 0; i < duration; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");

            Thread.Sleep(1000);
        }
    }

    public override void End()
    {
        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Breathing Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine();
        ShowSpinner(3);
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine();

        Console.WriteLine($"Set the duration for this activity (in seconds): {duration}");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            string question = questions[random.Next(questions.Count)];

            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine($"Question: {question}");

            ShowSpinner(5);
        }
    }

    public override void End()
    {
        Console.WriteLine();
        Console.WriteLine("Nice job! You have completed the Reflection Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine();
        ShowSpinner(3);
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a specific area.");
        Console.WriteLine();

        Console.WriteLine($"Set the duration for this activity (in seconds): {duration}");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("Start listing items now:");

        int itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrEmpty(item))
                break;

            itemCount++;
        }

        Console.WriteLine();
        Console.WriteLine($"item listed {itemCount} items.");

        ShowSpinner(3);
    }

    public override void End()
    {
        Console.WriteLine();
        Console.WriteLine("Nice job! You have completed the Listing Activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine();
        ShowSpinner(3);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("--------------------");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine();

        Console.Write("Choose an activity (1-3): ");
        int activityChoice = int.Parse(Console.ReadLine());

        Console.Write("Set the duration for this activity (in seconds): ");
        int duration = int.Parse(Console.ReadLine());

        MindfulnessActivity activity;

        switch (activityChoice)
        {
            case 1:
                activity = new BreathingActivity(duration);
                break;
            case 2:
                activity = new ReflectionActivity(duration);
                break;
            case 3:
                activity = new ListingActivity(duration);
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }

        Console.WriteLine();
        activity.Start();
        Console.WriteLine();
        activity.End();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
