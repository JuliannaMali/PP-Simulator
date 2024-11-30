using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    private bool fly;

    public override string Info
    {
        get
        {
            string flyyesno = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyyesno}) <{Size}>";
           
        }
    }

    public override char Symbol => CanFly ? 'B' : 'b';


    public override void Go(Direction direction)
    {
        if (CanFly)
        {
            Map?.Move(this, Position, Map.Next(Position, direction));
            Map?.Move(this, Position, Map.Next(Position, direction));
        }
        else
        {
            Map?.Move(this, Position, Map.NextDiagonal(Position, direction));
        }
    }

}
