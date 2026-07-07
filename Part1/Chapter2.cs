namespace category_theory.Part1;

static class Chapter2
{
    private static Func<A, B> Memoize<A, B>(Func<A, B> func) where A : notnull
    {
        Dictionary<A, B> memory = [];
        return a =>
        {
            if (memory.TryGetValue(a, out B? b))
            {
                return b;
            }
            var result = func(a);
            memory[a] = result;
            return result;
        };
    }

    private static string SlowFunction(string text)
    {
        Thread.Sleep(200);
        return "Hello: " + text + " I wish you all the best!";
    }

    private static void TestMemoize() {
        var memoized = Memoize<string, string>(SlowFunction);

        List<string> inputs = ["1", "2", "1", "1", "2"];
        Console.WriteLine("Not memoized running: ");
        inputs.ForEach(input => Console.WriteLine(SlowFunction(input)));
        Console.WriteLine("Memoized: ");
        inputs.ForEach(input => Console.WriteLine(memoized(input)));
        Console.WriteLine();
    }

    private static int UnsafeFactorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * UnsafeFactorial(n - 1);
        }
    }

    private static int Factorial(int n)
    {
        if (n < 0) {
            throw new ArgumentException("n must be positive!");
        }
        return UnsafeFactorial(n);
    }

    private static Func<int, int> memoizedUnsafeFactorial = Memoize<int, int>(UnsafeFactorial);
    private static int MemoizedFactorial(int n) {
        if (n < 0) {
            throw new ArgumentException("n must be positive!");
        }
        return memoizedUnsafeFactorial(n);
    }

    private static void TestMemoizeFactorial() {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Factorial(10);
        stopwatch.Stop();
        Console.WriteLine($"Factorial(10) took: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Restart();
        MemoizedFactorial(10);
        stopwatch.Stop();
        Console.WriteLine($"MemoizedFactorial(10) took: {stopwatch.ElapsedMilliseconds}ms");

        Console.WriteLine();
    }

    private readonly static List<Func<bool, bool>> allFunctionsFromBoolToBool = [
        Chapter1.Identity,  // identity
        b => !b,            // inverse
        _ => true,          // true
        _ => false,         // false
    ];

    public static void Run() {
        TestMemoize();
        TestMemoizeFactorial();
    }
}