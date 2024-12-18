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
}
