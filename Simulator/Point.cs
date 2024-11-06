using System.ComponentModel;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        if (direction == (Direction)0)
        {
            return new Point(X, Y + 1);
        }
        else if (direction == (Direction)1)
        {
            return new Point(X + 1, Y);
        }
        else if (direction == (Direction)2)
        {
            return new Point(X, Y - 1);
        }
        else if (direction == (Direction)3)
        {
            return new Point(X - 1, Y);
        }

        return default(Point);

    }

    // rotate given direction 45 degrees clockwise
    public Point NextDiagonal(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                {
                    return new Point(X+1, Y+1);
                }
            case Direction.Right:
                {
                    return new Point(X + 1, Y - 1);
                }
            case Direction.Down:
                {
                    return new Point(X - 1, Y - 1);
                }
            case Direction.Left:
                {
                    return new Point(X - 1, Y + 1);
                }            
        }
        return default(Point);
    }
}
