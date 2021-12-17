using Common.CharpHelpers;
using UnityEngine;

namespace Common.LerpAdapter
{
    public class Vector3LerpActionAdapter : LerpActionAdapter<Vector3>
    {
        public Vector3LerpActionAdapter(Vector3 a, Vector3 b, float t, Pointer<Vector3> value) : base(a, b, t, value)
        { }

        public override ILerpAction Lerp()
        {
            Value._ = Vector3.Lerp(A, B, T);
            return this;
        }
    }
}