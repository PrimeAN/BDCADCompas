namespace BDCAD_BusinessLogic
{
    public static class Extensions
    {
        public static bool IsInRange(this int value, int from, int to)
        {
            return value > from && value < to;
        }
    }
}