namespace category_theory.Part1;

class Circle(float radius) : IShape
{
    public float Radius { get; } = radius;
    public float Diameter => Radius * 2;
    public float Area => MathF.PI * Radius * Radius;
    public float Circumference => MathF.PI * Diameter;
}