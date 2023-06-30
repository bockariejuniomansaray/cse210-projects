public class Scripture
{
    public ScriptureReference Reference { get; }
    public string Text { get; }

    // List to store individual words in the scripture
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        Text = text;
        InitializeWords();
    }

    private void InitializeWords()
    {
        // Split the scripture text into words and create Word objects
        // Add the Word objects to the 'words' list
    }

    public void HideRandomWords(int count)
    {
        // Hide 'count' number of random words from the scripture
    }

    public bool AreAllWordsHidden()
    {
        // Check if all words in the scripture are hidden
        return words.All(word => word.IsHidden);
    }

    public override string ToString()
    {
        // Generate the formatted scripture text with hidden words
        // For example, "John 3:16 - For God so [hidden] the world..."
    }
}
