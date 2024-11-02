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
        string name = holder.ToUpper()[0] + holder.Substring(1);
        if (name.Length >= max)
        {
            return name.Substring(0, max);
        }
        if (name.Length<min)
        {
            return name.PadRight(min, placeholder);
        }
        if (name.Trim().Length<min)
        {
            return name.Trim().PadRight(min, placeholder);
        }
        return name;
    }
}
