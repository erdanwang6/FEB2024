namespace CSAssignment2;

public class ReversString
{
    public void Solution1()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Convert string to char array
        char[] charArray = input.ToCharArray();

        // Reverse the char array
        Array.Reverse(charArray);

        // Convert char array back to string
        string reversedString = new string(charArray);

        // Print the reversed string
        Console.WriteLine("Reversed string: " + reversedString);
    }

    public void Solution2()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Console.Write("Reversed string: ");

        // Loop through the string in reverse order and print each character
        for (int i = input.Length - 1; i >= 0; i--)
        {
            Console.Write(input[i]);
        }

        Console.WriteLine(); 
    }
}