namespace category_theory.Part1;

public interface Functor<T>
{
    public Functor<R> Map<R>(Func<T, R> f);
}

public static class Functor
{
    public static Functor<B> Map<A, B>(Func<A, B> f, Functor<A> fa)
    {
        return fa.Map(f);
    }
}