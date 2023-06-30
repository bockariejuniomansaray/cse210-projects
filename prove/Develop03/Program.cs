using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");
        scripture.Display();

        while (scripture.HasHiddenWords())
        {
            Console.WriteLine("Press ENTER to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            scripture.Display();
        }
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;
    private Random random;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.words = new List<Word>();
        this.random = new Random();

        string[] wordArray = text.Split(' ');

        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            words.Add(word);
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference);
        Console.WriteLine();

        foreach (Word word in words)
        {
            if (word.IsHidden)
                Console.Write("***** ");
            else
                Console.Write(word.Text + " ");
        }

        Console.WriteLine("\n");
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = words.FindAll(word => !word.IsHidden);

        if (visibleWords.Count > 0)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public bool HasHiddenWords()
    {
        return words.Exists(word => word.IsHidden);
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
