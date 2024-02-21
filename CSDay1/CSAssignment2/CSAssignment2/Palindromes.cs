using System.Text.RegularExpressions;

namespace CSAssignment2;

public class Palindromes
{
    public static List<string> ExtractAndSortPalindromes(string input)
    {
        var normalizedInput = input.ToLower();
        var matches = Regex.Matches(normalizedInput, @"\b[a-z]+\b");
        var palindromes = new HashSet<string>();

        foreach (Match match in matches)
        {
            var word = match.Value;
            if (IsPalindrome(word))
            {
                palindromes.Add(word);
            }
        }

        var sortedPalindromes = palindromes.ToList();
        sortedPalindromes.Sort();
        return sortedPalindromes;
    }

    static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;
        while (left < right)
        {
            if (word[left] != word[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}