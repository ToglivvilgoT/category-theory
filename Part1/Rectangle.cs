namespace category_theory.Part1;

class Rectangle(float width, float height) : IShape
{
    public float Width { get; } = width;
    public float Height { get; } = height;
    public float Area => Width * Height;
    public float Circumference => 2 * (Width + Height);
}