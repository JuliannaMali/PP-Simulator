namespace Simulator;

internal class Birds : Animals
{
    public bool CanFly { get; set; } = true;


    public override string Info
    {
        get
        {
            string flyyesno = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyyesno}) <{Size}>";
        }
    }

}
