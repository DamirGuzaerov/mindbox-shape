namespace Shapes;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (!IsRadiusPositive(radius))
        {
            throw new ArgumentException("Negative radius of the circle");
        }
        
        _radius = radius;
    }
    
    private bool IsRadiusPositive(double radius) => radius >= 0;

    public override double CalculateArea()
    {
        return Math.PI * (_radius * _radius);
    }
}