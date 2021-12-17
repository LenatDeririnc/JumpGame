using System.Collections.Generic;
using Common.Algorithms;
using UnityEngine;

namespace Common.Extensions
{
    public static class TransformExtensions
    {
        public static Vector3 CenterBounds(this IList<Transform> transforms) => 
            FindCenter.CenterBounds<Transform>(transforms, i => transforms[i].position);

        public static Vector3 Center(this IList<Transform> transforms) =>
            FindCenter.Center(transforms, i => transforms[i].position);
    }
}