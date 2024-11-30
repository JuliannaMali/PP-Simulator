namespace Simulator.Maps;

public interface IMappable
{
    public char Symbol { get; }
    void InitMapAndPosition(Map map, Point p);

    void Go(Direction direction);

}
