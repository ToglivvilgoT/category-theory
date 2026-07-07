namespace category_theory.Part1;

public static class Chapter1
{
    /// <summary>
    /// Identity function following the laws of:
    /// f . Identity = f = Identity . f
    /// for all functions f.
    /// </summary>
    public static T Identity<T> (T t)
    {
        return t;
    }

    /// <summary>
    /// Returns the function "f after g" = f . g
    /// </summary>
    public static Func<A, C> Compose<A, B, C>(Func<B, C> f, Func<A, B> g) {
        return a => f(g(a));
    }

    private static void TestIdentity()
    {
        Console.WriteLine("Testing Identity:");
        var inp = 7;
        Console.WriteLine("Identity(" + inp + ") = " + Identity(inp));
        var inp2 = "Hello";
        Console.WriteLine("Identity(" + inp2 + ") = " + Identity(inp2));
        var inp3 = ("Hello", 9, true, "World");
        Console.WriteLine("Identity(" + inp3 + ") = " + Identity(inp3));
        Console.WriteLine();
    }

    private static void TestCompose()
    {
        Console.WriteLine("Testing Compose");
        var f = (int a) => Convert.ToString(a);
        var g = (string a) => a.Length;
        var composed = Compose(f, g);
        var composed2 = Compose(g, f);
        var inp1 = "Hello World";
        var res1 = g(inp1);
        Console.WriteLine("result = g " + inp1 + " = " + res1);
        var res2 = f(res1);
        Console.WriteLine("f result = " + res2);
        Console.WriteLine("f . g " + inp1 + " = " + composed(inp1));
        var inp2 = 7;
        var res3 = f(inp2);
        Console.WriteLine("result = f " + inp2 + " = " + res3);
        var res4 = g(res3);
        Console.WriteLine("g result = " + res3);
        Console.WriteLine("g . f " + inp2 + " = " + composed2(inp2));
        Console.WriteLine();
    }

    /// <summary>
    /// Test that composition with identity function leaves the other function as is.
    /// </summary>
    private static void TestComposeRespectsIdentity()
    {
        var isEven = (int a) => a % 2 == 0;
        var leftId = Identity<int>;
        var rightId = Identity<bool>;
        var composedLeft = Compose(isEven, leftId);
        var composedRight = Compose(rightId, isEven);
        List<int> inputs = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        if (inputs.Select(input =>
        {
            var resultLeftComposed = composedLeft(input);
            var resultRightComposed = composedRight(input);
            var resultNotComposed = isEven(input);
            Console.WriteLine("Expected: " + resultNotComposed);
            Console.WriteLine("Left Composed: " + resultLeftComposed);
            Console.WriteLine("Right Composed: " + resultRightComposed);
            Console.WriteLine("====================");
            return resultLeftComposed == resultNotComposed && resultNotComposed == resultRightComposed;
        }).All(Identity))
        {
            Console.WriteLine("Composition did respect identity!");
        }
        else
        {
            Console.WriteLine("Composition did not respect identity!");
        }
        Console.WriteLine();
    }

    public static void Run()
    {
        TestIdentity();
        TestCompose();
        TestComposeRespectsIdentity();
    }
}