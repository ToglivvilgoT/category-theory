namespace category_theory.Part1;

public interface Bifunctor<A, B>
{
    public Bifunctor<C, D> Bimap<C, D>(Func<A, C> f, Func<B, D> g);
    
    public Bifunctor<C, B> First<C>(Func<A, C> f);

    public Bifunctor<A, C> Second<C>(Func<B, C> f);
}