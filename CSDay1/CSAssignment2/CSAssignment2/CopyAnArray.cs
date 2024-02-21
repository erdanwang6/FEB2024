namespace CSAssignment2;

public class CopyAnArray
{
    public void Solution()
    {
        int[] originalArray = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        
        // Create a second array with the same length as the first one
        int[] copiedArray = new int[originalArray.Length];
        
        // Use a loop to copy values from the original to the new array
        for (int i = 0; i < originalArray.Length; i++)
        {
            copiedArray[i] = originalArray[i];
        }
        
        // Print the contents of the original array
        Console.WriteLine("Original Array:");
        foreach (int item in originalArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine(); // Add a newline for better readability
        
        // Print the contents of the copied array
        Console.WriteLine("Copied Array:");
        foreach (int item in copiedArray)
        {
            Console.Write(item + " ");
        }
    }
}