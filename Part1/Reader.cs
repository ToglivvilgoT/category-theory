namespace category_theory.Part1;

public abstract class Reader<T> : Functor<T>
{
    public abstract T Read();

    public Reader<R> Map<R>(Func<T, R> f)
    {
        return new FunctionReader<R>(() => f(Read()));

        // Functor laws satisfied:
        //
        // Identity is preserved:
        // Reader<A>.Map(id).Read() = id(Read()) = Read()
        //
        // Composition is preserved:
        // Func<A, B> f;
        // Func<B, C> g;
        // Reader<A>.Map(f).Map(g).Read() =
        // g(f(Read())) =
        // Compose(g, f)(Read()) =
        // Reader<A>.Map(Compose(g, f)).Read()
    }

    Functor<R> Functor<T>.Map<R>(Func<T, R> f)
    {
        return Map(f);
    }
}

public class FunctionReader<T>(Func<T> f) : Reader<T>
{
    public override T Read()
    {
        return f();
    }
}
