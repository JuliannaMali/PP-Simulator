using System.Drawing;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    //w domu popraw wszystkie size
    
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


    public Rectangle Mapa(int Size)
    {
        Rectangle map = new Rectangle(0, 0, (Size - 1), (Size - 1));
        return map;
    }

    public override bool Exist(Point p)
    {
        return Mapa(Size).Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        if(p.X==Size-1 && d == Direction.Right)
        {
            return new Point (0, p.Y);
        }
        else if(p.X == 0 && d == Direction.Left)
        {
            return new Point(Size - 1, p.Y);
        }
        else if(p.Y == Size -1 && d == Direction.Up)
        {
            return new Point(p.X, 0);
        }
        else if(p.Y == 0 && d == Direction.Down)
        {
            return new Point(p.X, Size - 1);
        }
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (p.X == 0 && p.Y == 0 && d == Direction.Down)
        {
            return new Point(Size - 1, Size - 1);
        }
        else if (p.X == Size - 1 && p.Y == 0 && d == Direction.Right)
        {
            return new Point(0, Size - 1);
        }
        else if (p.X == Size -1 && p.Y == Size - 1 && d == Direction.Up)
        {
            return new Point(0, 0);
        }
        else if (p.X == 0 && p.Y == Size -1 && d == Direction.Left)
        {
            return new Point(Size - 1, 0);
        }
        else if (p.X == 0)
        {
            switch(d)
            {
                case Direction.Down:
                    return new Point(Size - 1, p.Y - 1);
                case Direction.Left:
                    return new Point(Size - 1, p.Y + 1);
            }   
        }
        else if (p.X == Size - 1)
        {
            switch(d)
            {
                case Direction.Up:
                    return new Point(0, p.Y + 1);
                case Direction.Right:
                    return new Point(0, p.Y - 1);
            }
        }
        else if (p.Y == 0)
        {
            switch(d)
            {
                case Direction.Right:
                    return new Point(p.X + 1, Size - 1);
                case Direction.Down:
                    return new Point(p.X - 1, Size - 1);
            }
        }
        else if (p.Y == Size - 1)
        {
            switch(d)
            {
                case Direction.Left:
                    return new Point(p.X - 1, 0);
                case Direction.Up:
                    return new Point(p.X + 1, 0);
            }
        }
        return p.NextDiagonal(d);
    }
}
