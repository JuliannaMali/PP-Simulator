namespace Simulator;

public static class Validator
{
    public static int LimiterEO(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        else
        {
            return value;
        }
    }

    public static string ShortnerCA(string value, int min, int max, char placeholder)
    {
        string holder = value.Trim();
        if (holder == "")
        {
            return holder.PadRight(min, placeholder);
        }
        string name = holder.ToUpper()[0] + holder.Substring(1);
        if (name.Length >= max)
        {
            name = name.Substring(0, max).Trim();
        }
        if (name.Trim().Length<min)
        {
            name = name.Trim().PadRight(min, placeholder);
        }
        return name;
    }
}
