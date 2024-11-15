using Simulator;
using System.Transactions;

namespace TestSimulator;

public class PointTest
{
    [Theory]
    [InlineData(1, 5, Direction.Up, 1, 6)]
    [InlineData(4, 7, Direction.Left, 3, 7)]
    [InlineData(5, 18, Direction.Down, 5, 17)]
    [InlineData(3, 10, Direction.Right, 4, 10)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction d, int expX, int expY)
    {
        var p = new Point(x, y);
        var next = p.Next(d);

        Assert.Equal(new Point(expX, expY), next);
    }

    [Theory]
    [InlineData(1, 5, Direction.Up, 2, 6)]
    [InlineData(4, 7, Direction.Left, 3, 8)]
    [InlineData(5, 18, Direction.Down, 4, 17)]
    [InlineData(3, 10, Direction.Right, 4, 9)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction d, int expX, int expY)
    {
        var p = new Point(x, y);
        var nextdiagonal = p.NextDiagonal(d);

        Assert.Equal(new Point(expX, expY), nextdiagonal);
    }
}
