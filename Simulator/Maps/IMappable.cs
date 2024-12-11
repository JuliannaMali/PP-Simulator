namespace Simulator.Maps;

public interface IMappable
{
    public char Symbol { get; }

    public string ToString();
    void InitMapAndPosition(Map map, Point p);

    void Go(Direction direction);

}
