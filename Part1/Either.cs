namespace category_theory.Part1;

public abstract class Either<A, B> : Bifunctor<A, B>
{
    public Either<C, D> Bimap<C, D>(Func<A, C> f, Func<B, D> g)
    {
        return First(f).Second(g);
    }

    public abstract Either<C, B> First<C>(Func<A, C> f);

    public abstract Either<A, C> Second<C>(Func<B, C> f);

    Bifunctor<C, D> Bifunctor<A, B>.Bimap<C, D>(Func<A, C> f, Func<B, D> g)
    {
        return Bimap(f, g);
    }

    Bifunctor<C, B> Bifunctor<A, B>.First<C>(Func<A, C> f)
    {
        return First(f);
    }

    Bifunctor<A, C> Bifunctor<A, B>.Second<C>(Func<B, C> f)
    {
        return Second(f);
    }
}

public class Left<A, B>(A value) : Either<A, B>
{
    public A value = value;

    public override Left<C, B> First<C>(Func<A, C> f)
    {
        return new(f(value));
    }

    public override Left<A, C> Second<C>(Func<B, C> f)
    {
        return new(value);
    }
}

public class Right<A, B>(B value) : Either<A, B>
{
    public B value = value;

    public override Right<C, B> First<C>(Func<A, C> f)
    {
        return new(value);
    }

    public override Right<A, C> Second<C>(Func<B, C> f)
    {
        return new(f(value));
    }

}