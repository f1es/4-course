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
        var textArray = text.Split(' ');
        var count = 0;
        foreach(var wordInArray  in textArray)
        {
            if (wordInArray == word)
                count++;
        }

        //var count = Regex.Matches(text, word).Count();
        Console.WriteLine($"В этом тексте {count} слов {word}");
    }
}
