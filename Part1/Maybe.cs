namespace category_theory.Part1;

public abstract class Maybe<T>
{
    public Maybe<T> Return(T value)
    {
        return new Just<T>(value);
    }

    public Maybe<T> Join(Maybe<Maybe<T>> mmt)
    {
        return mmt switch
        {
            Just<Maybe<T>> jmt => jmt.value,
            Nothing<Maybe<T>> _ => new Nothing<T>(),
            _ => throw new Exception("There can only be Just or Nothing"),
        };
    }

    public abstract Maybe<A> Map<A>(Func<T, A> f);

    public abstract Maybe<A> Bind<A>(Func<T, Maybe<A>> f);
}

public static class Maybe
{
    public static Func<A, Maybe<C>> Fish<A, B, C>(Func<A, Maybe<B>> f, Func<B, Maybe<C>> g)
    {
        return a => f(a).Bind(g);
    }
}

public class Just<T>(T value) : Maybe<T>
{
    public readonly T value = value;

    public override Maybe<A> Bind<A>(Func<T, Maybe<A>> f)
    {
        return f(value);
    }

    public override Maybe<A> Map<A>(Func<T, A> f)
    {
        return new Just<A>(f(value));
    }
}

public class Nothing<T>() : Maybe<T>
{
    public override Maybe<A> Bind<A>(Func<T, Maybe<A>> f)
    {
        return new Nothing<A>();
    }

    public override Maybe<A> Map<A>(Func<T, A> f)
    {
        return new Nothing<A>();
    }
}

