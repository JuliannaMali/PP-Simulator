namespace Simulator;

internal class Animals
{
    private string description = "Unidentified";
    public required string Description
    {
        get => description;
        init
        {
            description = Validator.ShortnerCA(value, 3, 15, '#');
        }
    }
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
