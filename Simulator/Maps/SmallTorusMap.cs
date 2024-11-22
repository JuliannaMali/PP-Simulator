using System.Drawing;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


    public Rectangle Mapa(int SizeX, int SizeY)
    {
        Rectangle map = new Rectangle(0, 0, (SizeX - 1), (SizeY - 1));
        return map;
    }

    public override bool Exist(Point p)
    {
        return Mapa(SizeX, SizeY).Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        if(p.X==SizeX-1 && d == Direction.Right)
        {
            return new Point (0, p.Y);
        }
        else if(p.X == 0 && d == Direction.Left)
        {
            return new Point(SizeX - 1, p.Y);
        }
        else if(p.Y == SizeY -1 && d == Direction.Up)
        {
            return new Point(p.X, 0);
        }
        else if(p.Y == 0 && d == Direction.Down)
        {
            return new Point(p.X, SizeY - 1);
        }
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (p.X == 0 && p.Y == 0 && d == Direction.Down)
        {
            return new Point(SizeX - 1, SizeY - 1);
        }
        else if (p.X == SizeX - 1 && p.Y == 0 && d == Direction.Right)
        {
            return new Point(0, SizeY - 1);
        }
        else if (p.X == SizeX -1 && p.Y == SizeY - 1 && d == Direction.Up)
        {
            return new Point(0, 0);
        }
        else if (p.X == 0 && p.Y == SizeY -1 && d == Direction.Left)
        {
            return new Point(SizeX - 1, 0);
        }
        else if (p.X == 0)
        {
            switch(d)
            {
                case Direction.Down:
                    return new Point(SizeX - 1, p.Y - 1);
                case Direction.Left:
                    return new Point(SizeX - 1, p.Y + 1);
            }   
        }
        else if (p.X == SizeX - 1)
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
                    return new Point(p.X + 1, SizeY - 1);
                case Direction.Down:
                    return new Point(p.X - 1, SizeY - 1);
            }
        }
        else if (p.Y == SizeY - 1)
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

    public override void Move(Creature creature, Point p, Direction d)
    {
        Remove(creature, p);
        Add(creature, Next(p, d));
    }
}
