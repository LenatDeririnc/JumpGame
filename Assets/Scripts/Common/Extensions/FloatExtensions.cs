using UnityEngine;

namespace Common.Extensions
{
    public static class FloatExtensions
    {
        public static float RatioBetween(this float value, float min, float max)
        {
            max -= min;
            value -= min;
            return Mathf.Clamp(value / max, 0, 1);
        }
    }
}