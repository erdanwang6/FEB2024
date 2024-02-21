namespace CSAssignment2;

public class FindsTheLongestSequenceOfEqualElements
{
    public void Solution()
    {
        Console.WriteLine("Enter an array of integers separated by spaces:");
        string input = Console.ReadLine();
        int[] array = input.Split(' ').Select(int.Parse).ToArray();

        int longestSequenceStart = 0;
        int longestSequenceLength = 1;
        int currentSequenceStart = 0;
        int currentSequenceLength = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentSequenceLength++;
                if (currentSequenceLength > longestSequenceLength)
                {
                    longestSequenceLength = currentSequenceLength;
                    longestSequenceStart = currentSequenceStart;
                }
            }
            else
            {
                currentSequenceStart = i;
                currentSequenceLength = 1;
            }
        }

        Console.WriteLine("Longest sequence of equal elements:");
        for (int i = longestSequenceStart; i < longestSequenceStart + longestSequenceLength; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}