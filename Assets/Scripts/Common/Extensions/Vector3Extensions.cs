using System.Collections.Generic;
using Common.Algorithms;
using UnityEngine;

namespace Common.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 Median(Vector3 point1, Vector3 point2) => 
            (point1 + (point2 - point1) * .5f);

        public static Vector3 CenterBounds(this IList<Vector3> positions) => 
            FindCenter.CenterBounds<Vector3>(positions, i => positions[i]);

        public static Vector3 Center(this IList<Vector3> positions) => 
            FindCenter.Center(positions, i => positions[i]);
    }
}