public class SchemaDemo
{
    /// <summary>
    /// Fakultät iterativ
    /// </summary>
    public static int Factorial(int n)
    {
        var result = 1;

        for (var i = 1; i <= n; i++)
            result = result * i;

        return result;
    }

    public static int FactorialRecursive(int n)
    {
        if (n == 0)
            return 1;

        return n * FactorialRecursive(n - 1);
    }

    public static long FibonacciRecursive(long len)
    {
        if (len == 1 || len == 2)
        {
            return 1;
        }
        return FibonacciRecursive(len - 1) + FibonacciRecursive(len - 2);
    }

    // Aufgabe 2
    public static long Fibonacci(uint a)
    {
        // Holds our two last fibonacci numbers for calculation.
        uint[] tmpFibonacci = { 0, 1 };

        // Case 2: skips loop, 0 + 1 = 1
        // Case 3: loops once, tf[0] = 0 + 1 => 1 + 1 = 2
        // Case 4: loops twice, tf[1] = 1 + 1 => 1 + 2 = 3
        // Case n: loops n-2 times, tf[n%2] = fib(n-1) + fib(n-2) => fib(n)
        for (int i = 2; i < a; i++)
            tmpFibonacci[i % 2] = tmpFibonacci[0] + tmpFibonacci[1];

        // Calculates the fibonacci for a;
        return tmpFibonacci[0] + tmpFibonacci[1];
    }
}
