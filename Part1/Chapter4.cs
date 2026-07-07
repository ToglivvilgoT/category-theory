namespace category_theory.Part1;

public static class Chapter4
{
    private static Maybe<double> SafeReciprocal(double a)
    {
        if (a == 0)
        {
            return new();
        }
        
        return new(1 / a);
    }

    private static Maybe<double> SafeRoot(double a)
    {
        if (a < 0)
        {
            return new();
        }

        return new(Math.Sqrt(a));
    }

    private static Maybe<double> SafeRootReciprocal(double a)
    {
        var f = Maybe<double>.Fish<double, double, double>(SafeReciprocal, SafeRoot);
        return f(a);
    }

    public static void Run()
    {
        Console.WriteLine("sqrt(1 / 9) = " + SafeRootReciprocal(9));
        Console.WriteLine("sqrt(1 / 0) = " + SafeRootReciprocal(0));
        Console.WriteLine("sqrt(1 / -4) = " + SafeRootReciprocal(-4));
    }
}