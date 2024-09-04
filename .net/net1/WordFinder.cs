using System.Text.RegularExpressions;

namespace net1;

public class WordFinder
{
    private string text;
    public WordFinder(string text)
    {
        this.text = text;
    }

    public void PrintWordCount(string word)
    {
        var count = Regex.Matches(text, word).Count();
        Console.WriteLine($"В этом тексте {count} слов {word}");
    }
}
