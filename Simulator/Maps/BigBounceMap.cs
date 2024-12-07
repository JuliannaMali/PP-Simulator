using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public readonly int Size;
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { } 

    public override Point Next(Point p, Direction d)
    {
        if(p.X == Size -1 && d == Direction.Right)
        {
            return p.Next(Direction.Left);
        }
        else if(p.X == 0 && d == Direction.Left)
        {
            return p.Next(Direction.Right);
        }
        else if(p.Y == Size - 1 && d == Direction.Up)
        {
            return p.Next(Direction.Down);
        }
        else if(p.Y == 0 && d == Direction.Down)
        {
            return p.Next(Direction.Up);
        }
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
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
        else if (p.X == SizeX - 1 && p.Y == 0)
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
        else if (p.X == SizeX - 1 && p.Y == SizeY - 1)
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
        else if (p.X == 0 && p.Y == Size - 1)
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
        else if (p.X == SizeX - 1)
        {
            switch (d)
            {
                case Direction.Up:
                    return p.NextDiagonal(Direction.Down);
                case Direction.Right:
                    return p.NextDiagonal(Direction.Left);
            }
        }
        else if (p.Y == SizeY - 1)
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
