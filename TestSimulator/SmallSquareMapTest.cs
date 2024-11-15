using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTest
{
    [Theory]
    [InlineData(6)]
    [InlineData(18)]
    [InlineData(20)]
    public void Construcotr_Valid_Size_ShouldCreateMap(int size)
    {
        var map = new SmallSquareMap(size);

        Assert.Equal(size, map.Size);
    }


    [Theory]
    [InlineData(3)]
    [InlineData(22)]
    public void Constructor_InvalidSize_ShouldThrowException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 19, 20, true)]
    [InlineData(1, 16, 20, true)]
    [InlineData(4, 15, 10, false)]
    [InlineData(-1, 4, 15, false)]
    [InlineData(0, 0, 11, true)]
    public void Exist_ShouldReturnCorrectValues(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var p1 = new Point(x, y);
        var result = map.Exist(p1);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(0, 4, Direction.Left, 0, 4)]
    [InlineData(5, 0, Direction.Down, 5, 0)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction d, int expX, int expY)
    {
        var map = new SmallSquareMap(10);
        var p = new Point(x, y);
        var nextPoint = map.Next(p, d);

        Assert.Equal(new Point(expX, expY), nextPoint);
    }

    [Theory]
    [InlineData(1, 3, Direction.Left, 0, 4)]
    [InlineData(0, 5, Direction.Up, 0, 5)]
    [InlineData(5, 3, Direction.Right, 5, 3)]
    [InlineData(4, 4, Direction.Down, 3, 3)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction d, int expX, int expY)
    {
        var map = new SmallSquareMap(6);
        var p = new Point(x, y);
        var next = map.NextDiagonal(p, d);

        Assert.Equal(new Point(expX, expY), next);
    }

}
