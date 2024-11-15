using Simulator;

namespace TestSimulator;

public class RectangleTest
{
    [Theory]
    [InlineData(1, 2, 3, 4, "(1,2) : (3,4)")]
    [InlineData(0, 0, 6, 6, "(0,0) : (6,6)")]
    public void Rectangle_ValidPoints_ShouldReturnExpected(int x1, int y1, int x2, int y2, string expected)
    {
        var rect = new Rectangle(x1, y1, x2, y2);
        var result = rect.ToString();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, 1, 4)]
    [InlineData(0, 0, 6, 0)]
    public void Rectangle_InvalidPoints_ShouldThrowExepction(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(1, 1, 2, 2, "(1,1) : (2,2)")]
    [InlineData(3, 4, 5, 6, "(3,4) : (5,6)")]
    public void Rectangle_CreationFromValidPoints_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, string expected)
    {
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var rect = new Rectangle(p1, p2);
        var result = rect.ToString();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(4, 7, 0, 3, "(0,3) : (4,7)")]
    [InlineData(5, 10, 1, 4, "(1,4) : (5,10)")]
    public void Rectangle_SwitchedPoints_ShouldReturnExpectedValue(int x1, int y1, int x2, int y2, string expected)
    {
        var rect = new Rectangle(x1, y1, x2, y2);
        var result = rect.ToString();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 2, true)]
    [InlineData(3, 5, true)]
    [InlineData(7, 2, false)]
    [InlineData(1, 8, false)]
    [InlineData(4, 4, true)]
    public void ContainsPoint_ShouldReturnExpectedValue(int x, int y, bool expected)
    {
        var p = new Point(x, y);
        var rectangle = new Rectangle(0, 0, 6, 6);
        var result = rectangle.Contains(p);

        Assert.Equal(expected, result);
    }



}
