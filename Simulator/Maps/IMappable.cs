namespace Simulator.Maps;

public interface IMappable
{
    void InitMapAndPosition(Map map, Point p);

    void Go(Direction direction);
}
