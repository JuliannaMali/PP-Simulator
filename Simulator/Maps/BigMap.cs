namespace Simulator.Maps;

public abstract class BigMap : Map
{
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX>1000)
        {
            throw new ArgumentException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 1000)
        {
            throw new ArgumentException(nameof(sizeY), "Too high");
        }

    }
}
