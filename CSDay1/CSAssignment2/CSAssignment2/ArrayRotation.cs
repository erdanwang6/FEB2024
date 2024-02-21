namespace CSAssignment2;

public class ArrayRotation
{
    public void Solution()
    {
        Console.WriteLine("Enter the array of integers (space-separated):");
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        // Reading the number of rotations
        Console.WriteLine("Enter the number of rotations:");
        int k = int.Parse(Console.ReadLine());

        int n = arr.Length;
        int[] sumArray = new int[n];

        // Rotating and summing the arrays
        for (int r = 1; r <= k; r++)
        {
            for (int i = 0; i < n; i++)
            {
                // Calculate the new position after r rotations
                int newPos = (i + r) % n;
                sumArray[newPos] += arr[i];
            }
        }

        Console.WriteLine("Resulting sum array:");
        Console.WriteLine(string.Join(" ", sumArray));
    }
}