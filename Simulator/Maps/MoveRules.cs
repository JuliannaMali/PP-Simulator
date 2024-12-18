using System.Drawing;

namespace Simulator.Maps;

internal static class MoveRules
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        var moved = p.Next(d);
        if (!m.Exist(moved)) return p;
        return moved;
    }

    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        if (!m.Exist(moved)) return p;
        return moved;
    }

    public static Point TorusNext(Map m, Point p, Direction d)
    {
        if (p.X == m.SizeX - 1 && d == Direction.Right)
        {
            return new Point(0, p.Y);
        }
        else if (p.X == 0 && d == Direction.Left)
        {
            return new Point(m.SizeX - 1, p.Y);
        }
        else if (p.Y == m.SizeY - 1 && d == Direction.Up)
        {
            return new Point(p.X, 0);
        }
        else if (p.Y == 0 && d == Direction.Down)
        {
            return new Point(p.X, m.SizeY - 1);
        }
        return p.Next(d);
    }

    public static Point TorusNextDiagonal(Map m, Point p, Direction d)
    {
        if (p.X == 0 && p.Y == 0 && d == Direction.Down)
        {
            return new Point(m.SizeX - 1, m.SizeY - 1);
        }
        else if (p.X == m.SizeX - 1 && p.Y == 0 && d == Direction.Right)
        {
            return new Point(0, m.SizeY - 1);
        }
        else if (p.X == m.SizeX - 1 && p.Y == m.SizeY - 1 && d == Direction.Up)
        {
            return new Point(0, 0);
        }
        else if (p.X == 0 && p.Y == m.SizeY - 1 && d == Direction.Left)
        {
            return new Point(m.SizeX - 1, 0);
        }
        else if (p.X == 0)
        {
            switch (d)
            {
                case Direction.Down:
                    return new Point(m.SizeX - 1, p.Y - 1);
                case Direction.Left:
                    return new Point(m.SizeX - 1, p.Y + 1);
            }
        }
        else if (p.X == m.SizeX - 1)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point(0, p.Y + 1);
                case Direction.Right:
                    return new Point(0, p.Y - 1);
            }
        }
        else if (p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return new Point(p.X + 1, m.SizeY - 1);
                case Direction.Down:
                    return new Point(p.X - 1, m.SizeY - 1);
            }
        }
        else if (p.Y == m.SizeY - 1)
        {
            switch (d)
            {
                case Direction.Left:
                    return new Point(p.X - 1, 0);
                case Direction.Up:
                    return new Point(p.X + 1, 0);
            }
        }
        return p.NextDiagonal(d);
    }

    public static Point BounceNext(Map m, Point p, Direction d)
    {
        if (p.X == m.SizeX - 1 && d == Direction.Right)
        {
            return p.Next(Direction.Left);
        }
        else if (p.X == 0 && d == Direction.Left)
        {
            return p.Next(Direction.Right);
        }
        else if (p.Y == m.SizeY - 1 && d == Direction.Up)
        {
            return p.Next(Direction.Down);
        }
        else if (p.Y == 0 && d == Direction.Down)
        {
            return p.Next(Direction.Up);
        }
        return p.Next(d);
    }

    public static Point BounceNextDiagonal(Map m, Point p, Direction d)
    {
        if (p.X == 0 && p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return p;
                case Direction.Left:
                    return p;
                case Direction.Down:
                    return p.NextDiagonal(Direction.Up);
            }
        }
        else if (p.X == m.SizeX - 1 && p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
                case Direction.Down:
                    return p;
                case Direction.Up:
                    return p;
            }
        }
        else if (p.X == m.SizeX - 1 && p.Y == m.SizeY - 1)
        {
            switch (d)
            {
                case Direction.Right:
                    return p;
                case Direction.Left:
                    return p;
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
            }
        }
        else if (p.X == 0 && p.Y == m.SizeY - 1)
        {
            switch (d)
            {
                case Direction.Left:
                    return p.NextDiagonal(Direction.Right);
                case Direction.Down:
                    return p;
                case Direction.Up:
                    return p;
            }
        }
        else if (p.Y == 0)
        {
            switch (d)
            {
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
                case Direction.Down:
                    return p.NextDiagonal(Direction.Up);
            }
        }
        else if (p.X == m.SizeX - 1)
        {
            switch (d)
            {
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
            }
        }
        else if (p.Y == m.SizeY - 1)
        {
            switch (d)
            {
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
                case Direction.Left:
                    return p.NextDiagonal(Direction.Right);
            }
        }
        else if (p.X == 0)
        {
            switch (d)
            {
                case Direction.Left:
                    return p.NextDiagonal(Direction.Right);
                case Direction.Down:
                    return p.NextDiagonal(Direction.Up);
            }
        }

        return p.NextDiagonal(d);
    }
}
