using System.Text.RegularExpressions;

namespace CSAssignment2;

public class ReverseSentenceKeepingPunctuation
{
    public static string Solution(string sentence)
    {
        // Define separators as a regex pattern (including space)
        string pattern = @"([.,:;=()\[\]&""'\\/!? ])";
        
        // Split the sentence into words and separators
        List<string> tokens = new List<string>(Regex.Split(sentence, $"({pattern})"));
        
        // Remove any empty entries that may result from split
        tokens.RemoveAll(item => string.IsNullOrWhiteSpace(item));
        
        // Reverse the list of words, ignoring punctuation and spaces
        int start = 0, end = tokens.Count - 1;
        while (start < end)
        {
            if (!Regex.IsMatch(tokens[start], pattern) && !Regex.IsMatch(tokens[end], pattern))
            {
                (tokens[start], tokens[end]) = (tokens[end], tokens[start]);
                start++;
                end--;
            }
            else
            {
                if (Regex.IsMatch(tokens[start], pattern)) start++;
                if (Regex.IsMatch(tokens[end], pattern)) end--;
            }
        }

        // Reassemble the sentence
        return string.Join("", tokens);
    }
}