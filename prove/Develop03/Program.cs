class Program
{
    static void Main()
    {
        // Initialize the scripture
        var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display the complete scripture
        Console.WriteLine(scripture.ToString());

        // Prompt the user
        Console.WriteLine("Press Enter to hide words or type 'quit' to end.");

        while (!scripture.AreAllWordsHidden())
        {
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            // Hide a few random words and display the updated scripture
            scripture.HideRandomWords(2);
            Console.Clear();
            Console.WriteLine(scripture.ToString());
            Console.WriteLine("Press Enter to hide words or type 'quit' to end.");
        }

        Console.WriteLine("Program ended.");
    }
}
