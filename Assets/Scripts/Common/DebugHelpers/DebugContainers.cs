using System;

namespace Common.DebugHelpers
{
    public static class DebugContainers
    {
        public static void InfiniteCycle(ref int value, int maxValue)
        {
            value += 1;
            if (value > maxValue)
                throw new Exception("Infinite cycle");
        }
    }
}