using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Algorithms
{
    public static class FindCenter
    {
        public static Vector3 CenterBounds<T>(IList<T> positions, Func<int, Vector3> getPosition)
        {
            Bounds bound = new Bounds(getPosition(0), Vector3.zero);
            for(int i = 0; i < positions.Count; i++)
            {
                bound.Encapsulate(getPosition(i));
            }
            return bound.center;
        }

        public static Vector3 Center<T>(IList<T> positions, Func<int, Vector3> getPosition)
        {
            Vector3 total = Vector3.zero;
            for (var index = 0; index < positions.Count; index++)
            {
                total += getPosition(index);
            }
            return total / positions.Count;
        }
    }
}