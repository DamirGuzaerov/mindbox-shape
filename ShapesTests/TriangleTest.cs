using Shapes;

namespace ShapesTests;

public class TriangleTest
{
    [Theory]
    [MemberData(nameof(ZeroSideData))]
    public void ZeroSideTest(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
    
    [Theory]
    [MemberData(nameof(NegativeSideData))]
    public void NegativeSideTest(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
    
    [Theory]
    [MemberData(nameof(NotExistingTriangleData))]
    public void NotExistingTriangleTest(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }


    [Theory]
    [MemberData(nameof(CorrectTriangleData))]
    public void CorrectTriangleTest(double sideA, double sideB, double sideC, double epsilon, double expected)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        var area = triangle.CalculateArea();
        Assert.True(Math.Abs(expected - area) <= epsilon);
    }
    
    [Theory]
    [MemberData(nameof(RightTriangleData))]
    public void RightTrianguleTest(double sideA, double sideB, double sideC, bool expected)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        var result = triangle.IsTriangleRight();
        Assert.Equal(expected, result);
    }
    
    public static IEnumerable<object[]> ZeroSideData()
    {
        yield return new object[] {0, 1, 2};
        yield return new object[] {1, 0, 2};
        yield return new object[] {1, 2, 0};
        yield return new object[] {0, 0, 0};
    }

    public static IEnumerable<object[]> NegativeSideData()
    {
        yield return new object[] {-1, 12, 123};
        yield return new object[] {1, -12, 123};
        yield return new object[] {1, 12, -123};
        yield return new object[] {-1, -12, -123};
    }
    
    public static IEnumerable<object[]> NotExistingTriangleData()
    {
        yield return new object[] {1, 12, 123};
        yield return new object[] {1, 12, 123};
    }

    public static IEnumerable<object[]> CorrectTriangleData()
    {
        yield return new object[] {3, 4, 5, 0, 6};
        yield return new object[] {5, 5, 6, 0, 12};
        yield return new object[] {5, 5, 7, 1e-5, 12.4975};
    }

    public static IEnumerable<object[]> RightTriangleData()
    {
        yield return new object[] {3, 4, 5, true};
        yield return new object[] {3, 5, 4, true};
        yield return new object[] {4, 3, 5, true};
        yield return new object[] {4, 5, 3, true};
        yield return new object[] {5, 3, 4, true};
        yield return new object[] {5, 4, 3, true};
        yield return new object[] {5, 5, 6, false};
    }
}