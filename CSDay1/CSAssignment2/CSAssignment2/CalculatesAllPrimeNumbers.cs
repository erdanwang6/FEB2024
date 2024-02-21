namespace CSAssignment2;

public class CalculatesAllPrimeNumbers
{
    public static int[] FindPrimesInRange(int start, int end)
    {
        List<int> primes = new List<int>();
        for (int num = start; num <= end; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }
        return primes.ToArray();
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}