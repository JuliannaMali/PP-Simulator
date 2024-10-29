namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string arg)
        {
            Direction[] dir = { };

            foreach(char element in arg)
            {
                string element1 = element.ToString().ToLower();

                if (element1 == "u")
                {
                    Array.Resize(ref dir, dir.Length+1);
                    dir[^1] = (Direction)0;
                }
                else if (element1 == "r")
                {
                    Array.Resize(ref dir, dir.Length + 1);
                    dir[^1] = (Direction)1;
                }
                else if (element1 == "d")
                {
                    Array.Resize(ref dir, dir.Length + 1);
                    dir[^1] = (Direction)2;
                }
                else if (element1 == "l")
                {
                    Array.Resize(ref dir, dir.Length + 1);
                    dir[^1] = (Direction)3;
                }
            }

            return dir;
        }

    }
}
