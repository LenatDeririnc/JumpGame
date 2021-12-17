using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Extensions
{
    public static class ListExtensions
    {
        public static T First<T>(this IList<T> list) =>
            list[0];

        public static T Last<T>(this IList<T> list) => 
            list[list.Count - 1];

        public static T Cycle<T>(this IList<T> list, int index) => 
            list[index % list.Count];
        
        public static T PeakRandom<T>(this IList<T> array)
        {
            int rand = Random.Range(0, array.Count);
            return array[rand];
        }

        public static float MiddleValue(this IList<float> array)
        {
            var sum = array.Sum();
            var length = array.Count;
            return sum / length;
        }

        public static float Minimum(this IList<float> array)
        {
            float min = array[0];
            return array.Prepend(min).Min();
        }
    }
}