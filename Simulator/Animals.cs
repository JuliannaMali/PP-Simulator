using System.Xml.Linq;

namespace Simulator;

internal class Animals
{
    private string description = "Unidentified";
    public required string Description
    {
        get => description;
        init
        {
            description = value.Length > 0 ? value.ToUpper()[0] + value.Substring(1) : "Unknown";
            description = description.Length < 15 ? description : description.Substring(0, 14);
            description = description.Trim();
            description = description.Length >= 3 ? description : description.PadRight(3, '#');
            description = (description.Trim().Length <= 3) ? description.Trim().PadRight(3, '#') : description.Trim();
        }
    }
    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
