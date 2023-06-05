namespace Shapes;

public class Triangle : Shape
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;
    private readonly double[] _sortedSides;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (!IsExists(sideA, sideB, sideC))
            throw new ArgumentException("A triangle with such sides does not exist");
        
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
        
        _sortedSides = new[] {_sideA, _sideB, _sideC}.OrderByDescending(side => side).ToArray();
    }
    
    public override double CalculateArea()
    {
        var semiperimeter = (_sideA + _sideB + _sideC) / 2;
        return Math.Sqrt(semiperimeter * (semiperimeter - _sideA) * (semiperimeter - _sideB) * (semiperimeter - _sideC));
    }
    
    private bool IsExists(double sideA, double sideB, double sideC)
    {
        return sideA + sideB > sideC && sideB + sideC > sideA && sideA + sideC > sideB;
    }
    
    
    public bool IsTriangleRight()
    {
        var hypotenuse = _sortedSides[0];
        var cathetA = _sortedSides[1];
        var cathetB = _sortedSides[2];
        
        return Math.Abs(hypotenuse * hypotenuse - cathetA * cathetA - cathetB * cathetB) < double.Epsilon;
    }
}