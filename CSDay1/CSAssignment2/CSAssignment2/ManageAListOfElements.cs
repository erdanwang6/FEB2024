namespace CSAssignment2;

public class ManageAListOfElements
{
    public void Solution()
    {
         List<string> itemList = new List<string>();

        while (true) // Infinite loop
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
            string input = Console.ReadLine();
            string command = input.Substring(0, 1); // Get the first character to identify the command

            switch (command)
            {
                case "+":
                    // Add item to the list
                    string addItem = input.Substring(2); // Extract the item to add, skipping the command and space
                    itemList.Add(addItem);
                    Console.WriteLine($"Added: {addItem}");
                    break;
                case "-":
                    // Remove item from the list
                    string removeItem = input.Substring(2); // Extract the item to remove, skipping the command and space
                    if (itemList.Contains(removeItem))
                    {
                        itemList.Remove(removeItem);
                        Console.WriteLine($"Removed: {removeItem}");
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                    break;
                case "--":
                    if (input == "--")
                    {
                        // Clear the list
                        itemList.Clear();
                        Console.WriteLine("List cleared.");
                        break;
                    }
                    goto default; // If the input is not exactly "--", treat it as an invalid command
                default:
                    // Handle invalid commands
                    Console.WriteLine("Invalid command. Please enter + item, - item, or -- to clear.");
                    break;
            }

            // Show current list contents
            Console.WriteLine("Current list:");
            foreach (string item in itemList)
            {
                Console.WriteLine(item);
            }
        }
    }
}