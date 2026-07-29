using System.Collections;

namespace category_theory.Part1;

public static class Chapter6
{
    private static Either<A, Unit> Convert1<A>(Maybe<A> maybe)
    {
        return maybe switch
        {
            Just<A> justA => new Left<A, Unit>(justA.value),
            Nothing<A> _ => new Right<A, Unit>(Unit.unit),
            _ => throw new Exception(),
        };
    }

    private static Maybe<A> Convert2<A>(Either<A, Unit> either)
    {
        return either switch
        {
            Left<A, Unit> left => new Just<A>(left.value),
            Right<A, Unit> => new Nothing<A>(),
            _ => throw new Exception(),
        };
    }

    private static Either<A, A> Convert3<A>((bool, A) value)
    {
        var (boolean, a) = value;

        return boolean switch
        {
            true => new Left<A, A>(a),
            false => new Right<A, A>(a),
        };
    }

    private static (bool, A) Convert4<A>(Either<A, A> value)
    {
        return value switch
        {
            Left<A, A> left => (true, left.value),
            Right<A, A> right => (false, right.value),
            _ => throw new Exception(),
        };
    }
}