namespace CSAssignment2;

public class MostFrequentNumber
{
    public void Solution()
    {
        Console.WriteLine("Enter numbers separated by space:");
        string input = Console.ReadLine();
        string[] tokens = input.Split(' ');

        // Convert input to list of integers
        List<int> numbers = new List<int>();
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                numbers.Add(number);
            }
        }

        // Dictionary to hold number and its frequency
        Dictionary<int, int> frequencyDict = new Dictionary<int, int>();

        // Populate the dictionary with frequencies
        foreach (var number in numbers)
        {
            if (frequencyDict.ContainsKey(number))
            {
                frequencyDict[number]++;
            }
            else
            {
                frequencyDict[number] = 1;
            }
        }

        // Find the most frequent number
        int mostFrequentNumber = numbers[0]; // Start with the first number
        int maxFrequency = 0;

        foreach (var number in numbers)
        {
            int frequency = frequencyDict[number];
            if (frequency > maxFrequency)
            {
                mostFrequentNumber = number;
                maxFrequency = frequency;
            }
        }

        Console.WriteLine($"Most frequent number is: {mostFrequentNumber}");
    }
}