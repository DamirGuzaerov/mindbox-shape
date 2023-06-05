using Shapes;

namespace ShapesTests;

public class CircleTest
{
    
    [Fact]
    public void ZeroRadiusTest()
    {
        var radius = 0;
        var expected = 0;
        var circle = new Circle(radius);
        
        var area = circle.CalculateArea();

        Assert.Equal(expected, area);
    }
    
    [Fact]
    public void NegativeRadiusTest()
    {
        var radius = -10;
        
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Fact]
    public void CorrectCircleTest()
    {
        var radius = 10;
        var expected = Math.PI * radius * radius;
        var circle = new Circle(radius);
        
        var area = circle.CalculateArea();

        Assert.True(Math.Abs(expected - area) < double.Epsilon);
    }
}