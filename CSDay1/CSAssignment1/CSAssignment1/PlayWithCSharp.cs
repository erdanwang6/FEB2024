// See https://aka.ms/new-console-template for more information

//Playing with Console App

string sign, color, street, hacherName;

Console.WriteLine("your astrology sign:");
sign = Console.ReadLine();
Console.WriteLine("your favorite color:");
color = Console.ReadLine();
Console.WriteLine("your street number:");
street = Console.ReadLine();
hacherName = color + sign + street;
Console.WriteLine($"your hacker name is {hacherName}");

// Practice number sizes and ranges
//
// 1. Create a console application project named /02UnderstandingTypes/ that outputs the
// number of bytes in memory that each of the following number types uses, and the
//     minimum and maximum values they can have: sbyte, byte, short, ushort, int, uint, long,
// ulong, float, double, and decimal.

Console.WriteLine("Type    Byte(s) of memory    Min                            Max");

// sbyte
Console.WriteLine(
    $"sbyte   {sizeof(sbyte)}                   {sbyte.MinValue}                           {sbyte.MaxValue}");
// byte
Console.WriteLine(
    $"byte    {sizeof(byte)}                    {byte.MinValue}                           {byte.MaxValue}");
// short
Console.WriteLine(
    $"short   {sizeof(short)}                   {short.MinValue}                          {short.MaxValue}");
// ushort
Console.WriteLine(
    $"ushort  {sizeof(ushort)}                  {ushort.MinValue}                         {ushort.MaxValue}");
// int
Console.WriteLine(
    $"int     {sizeof(int)}                     {int.MinValue}                            {int.MaxValue}");
// uint
Console.WriteLine(
    $"uint    {sizeof(uint)}                    {uint.MinValue}                           {uint.MaxValue}");
// long
Console.WriteLine(
    $"long    {sizeof(long)}                    {long.MinValue}                           {long.MaxValue}");
// ulong
Console.WriteLine(
    $"ulong   {sizeof(ulong)}                   {ulong.MinValue}                          {ulong.MaxValue}");
// float
Console.WriteLine(
    $"float   {sizeof(float)}                   {float.MinValue}                          {float.MaxValue}");
// double
Console.WriteLine(
    $"double  {sizeof(double)}                  {double.MinValue}                         {double.MaxValue}");
// decimal
Console.WriteLine(
    $"decimal {sizeof(decimal)}                 {decimal.MinValue}                        {decimal.MaxValue}");

// 2. Write program to enter an integer number of centuries and convert it to years, days, hours,
//     minutes, seconds, milliseconds, microseconds, nanoseconds. Use an appropriate data
// type for every data conversion. Beware of overflows!
// Input: 1
// Output: 1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes
//     = 3155673600 seconds = 3155673600000 milliseconds = 3155673600000000
// microseconds = 3155673600000000000 nanoseconds
// Input: 5
// Output: 5 centuries = 500 years = 182621 days = 4382904 hours = 262974240
// minutes = 15778454400 seconds = 15778454400000 milliseconds = 15778454400000000
// microseconds = 15778454400000000000 nanoseconds

Console.Write("Enter the number of centuries: ");
int centuries = int.Parse(Console.ReadLine());

int years = centuries * 100;
int days = (int)(years * 365.2422); // Average days per year considering leap years
long hours = days * 24L;
long minutes = hours * 60L;
long seconds = minutes * 60L;
long milliseconds = seconds * 1000L;
long microseconds = milliseconds * 1000L;
ulong nanoseconds = (ulong)microseconds * 1000UL; // Using ulong for nanoseconds to handle larger values

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = " +
                  $"{minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = " +
                  $"{microseconds} microseconds = {nanoseconds} nanoseconds");

Console.WriteLine(0.0 / 0.0);
Console.WriteLine(1.0 / 0);


Console.WriteLine("FizzBuzz Game Simulation up to 100");


// FizzBuzzis a group word game for children to teach them about division. Players take turns
//     to count incrementally, replacing any number divisible by three with the word /fizz/, any
//     number divisible by five with the word /buzz/, and any number divisible by both with /
//     fizzbuzz/.
// Create a console application in Chapter03 named Exercise03 that outputs a simulated
//     FizzBuzz game counting up to 100.

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("Game Over. Press any key to exit.");
Console.ReadKey();


int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
}

// Write a program that generates a random number between 1 and 3 and asks the user to
//     guess what the number is. Tell the user if they guess low, high, or get the correct answer.
//     Also, tell the user if their answer is outside of the range of numbers that are valid guesses
//     (less than 1 or more than 3).

Random random = new Random();
int randomNumber = random.Next(1, 4); // The upper bound is exclusive

Console.WriteLine("Guess the number (between 1 and 3):");

while (true)
{
    string input = Console.ReadLine();
    int guess;

    // Check if input is a valid integer
    if (!int.TryParse(input, out guess))
    {
        Console.WriteLine("Please enter a valid number.");
        continue;
    }

    // Check if the guess is within the valid range
    if (guess < 1 || guess > 3)
    {
        Console.WriteLine("Your guess is outside the valid range. Please guess a number between 1 and 3.");
    }
    else if (guess < randomNumber)
    {
        Console.WriteLine("Your guess is too low. Try again:");
    }
    else if (guess > randomNumber)
    {
        Console.WriteLine("Your guess is too high. Try again:");
    }
    else
    {
        Console.WriteLine("Congratulations! You guessed the correct number.");
        break; // Exit the loop if the guess is correct
    }
}

// Print-a-Pyramid.Like the star pattern examples that we saw earlier, create a program that
//     will print the following pattern: If you find yourself getting stuck, try recreating the two
//     examples that we just talked about in this chapter first. They’re simpler, and you can
// compare your results with the code included above.
//     This can actually be a pretty challenging problem, so here is a hint to get you going. I used
// three total loops. One big one contains two smaller loops. The bigger loop goes from line
// to line. The first of the two inner loops prints the correct number of spaces, while the
//     second inner loop prints out the correct number of stars.
//       *
//      ***
//     *****
//    *******
//   *********
int n = 5; // Height of the pyramid

for (int i = 1; i <= n; i++) // Loop for each line
{
    // Loop for printing spaces
    for (int j = 1; j <= n - i; j++)
    {
        Console.Write(" ");
    }

    // Loop for printing stars
    for (int k = 1; k <= 2 * i - 1; k++)
    {
        Console.Write("*");
    }

    // Move to the next line
    Console.WriteLine();
}

// Write a program that generates a random number between 1 and 3 and asks the user to
//     guess what the number is. Tell the user if they guess low, high, or get the correct answer.
//     Also, tell the user if their answer is outside of the range of numbers that are valid guesses
//     (less than 1 or more than 3). You can convert the user's typed answer from a string to an
// int using this code:
// int guessedNumber = int.Parse(Console.ReadLine());
// Note that the above code will crash the program if the user doesn't type an integer value.
//     For this exercise, assume the user will only enter valid guesses.
Random random1 = new Random();
int randomNumber1 = random1.Next(1, 4); // Generates a random number between 1 and 3

Console.WriteLine("Guess the number (between 1 and 3):");
int guessedNumber = int.Parse(Console.ReadLine()); // Assuming valid integer input

// Check if the guess is outside the valid range
if (guessedNumber < 1 || guessedNumber > 3)
{
    Console.WriteLine("Your guess is outside the valid range of numbers. Please guess between 1 and 3.");
}
else if (guessedNumber < randomNumber1)
{
    Console.WriteLine("Your guess is too low.");
}
else if (guessedNumber > randomNumber1)
{
    Console.WriteLine("Your guess is too high.");
}
else
{
    Console.WriteLine("Congratulations! You guessed the correct number.");
}

// Write a simple program that defines a variable representing a birth date and calculates
// how many days old the person with that birth date is currently.
//     For extra credit, output the date of their next 10,000 day (about 27 years) anniversary.
//     Note: once you figure out their age in days, you can calculate the days until the next
// anniversary using int daysToNextAnniversary = 10000 - (days % 10000); .
DateTime birthDate = new DateTime(1995, 5, 23); // Example: May 23, 1995
        
// Calculate age in days
DateTime today = DateTime.Today;
int daysOld = (today - birthDate).Days;
        
// Output current age in days
Console.WriteLine($"You are {daysOld} days old.");
        
// Calculate days to next 10,000 day anniversary
int daysToNextAnniversary = 10000 - (daysOld % 10000);
        
// Output the date of the next 10,000 day anniversary
DateTime nextAnniversary = today.AddDays(daysToNextAnniversary);
Console.WriteLine($"Your next 10,000 day anniversary will be on {nextAnniversary.ToShortDateString()}.");

// Write a program that greets the user using the appropriate greeting for the time of day.
//     Use only if , not else or switch , statements to do so. Be sure to include the following
// greetings:
// "Good Morning"
// "Good Afternoon"
// "Good Evening"
// "Good Night"
// It's up to you which times should serve as the starting and ending ranges for each of the
// greetings. If you need a refresher on how to get the current time, see DateTime
// Formatting. When testing your program, you'll probably want to use a DateTime variable
// you define, rather than the current time. Once you're confident the program works
//     correctly, you can substitute DateTime.Now for your variable (or keep your variable and just
// assign DateTime.Now as its value, which is often a better approach).
static void GreetUser(DateTime time)
{
    int hour = time.Hour;

    // Good Morning: 5:00 AM - 11:59 AM
    if (hour >= 5 && hour < 12)
    {
        Console.WriteLine("Good Morning");
    }

    // Good Afternoon: 12:00 PM - 4:59 PM
    if (hour >= 12 && hour < 17)
    {
        Console.WriteLine("Good Afternoon");
    }

    // Good Evening: 5:00 PM - 8:59 PM
    if (hour >= 17 && hour < 21)
    {
        Console.WriteLine("Good Evening");
    }

    // Good Night: 9:00 PM - 4:59 AM
    if (hour >= 21 || hour < 5)
    {
        Console.WriteLine("Good Night");
    }
}
DateTime currentTime = DateTime.Now; // Or set a specific time for testing e.g., new DateTime(2022, 1, 1, 15, 30, 0);

Console.WriteLine($"Current time: {currentTime.ToString("HH:mm:ss")}");
GreetUser(currentTime);

// Write a program that prints the result of counting up to 24 using four different increments.
//     First, count by 1s, then by 2s, by 3s, and finally by 4s.
//     Use nested for loops with your outer loop counting from 1 to 4. You inner loop should
//     count from 0 to 24, but increase the value of its /loop control variable/ by the value of the /
//     loop control variable/ from the outer loop. This means the incrementing in the /
//     afterthought/ expression will be based on a variable.
//     Your output should look something like this:
// 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24
// 0,2,4,6,8,10,12,14,16,18,20,22,24
// 0,3,6,9,12,15,18,21,24
// 0,4,8,12,16,20,24

for (int increment = 1; increment <= 4; increment++)
{
    // Inner loop for counting from 0 to 24
    for (int i = 0; i <= 24; i += increment)
    {
        // Print the current number followed by a comma, except for the last number
        Console.Write(i != 24 ? $"{i}," : $"{i}");
                
        // Adjust to only print the last number in the sequence without an extra comma
        if (i + increment > 24)
        {
            Console.Write(i);
            break;
        }
    }
    // Move to the next line for the next increment sequence
    Console.WriteLine();
}