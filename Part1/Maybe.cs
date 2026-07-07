namespace category_theory.Part1;

public class Maybe<T>
{
    private readonly bool valid;
    private readonly T? value;

    public Maybe()
    {
        valid = false;
    }

    public Maybe(T value)
    {
        valid = true;
        this.value = value;
    }

    public Maybe<R> Map<R>(Func<T, R> f)
    {
        if (valid)
        {
            return new(f(value!));
        }
        else
        {
            return new();
        }
    }

    public Maybe<R> Bind<R>(Func<T, Maybe<R>> f)
    {
        if (!valid)
        {
            return new();
        }
        else
        {
            return f(value!);
        }
    } 

    public static Func<A, Maybe<C>> Fish<A, B, C>(Func<A, Maybe<B>> f, Func<B, Maybe<C>> g)
    {
        return a =>
        {
            var maybeB = f(a);
            if (!maybeB.valid)
            {
                return new();
            }
            else 
            {
                return g(maybeB.value!);
            }
        };
    }

    public static Maybe<A> Join<A>(Maybe<Maybe<A>> mma)
    {
        if (!mma.valid)
        {
            return new();
        }
        else
        {
            return mma.value!;
        }
    }

    public override string ToString()
    {
        if (valid)
        {
            return "Just " + value;
        }
        else
        {
            return "Nothing";
        }
    }
}
