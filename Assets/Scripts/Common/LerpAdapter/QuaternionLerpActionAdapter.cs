using Common.CharpHelpers;
using UnityEngine;

namespace Common.LerpAdapter
{
    public class QuaternionLerpActionAdapter : LerpActionAdapter<Quaternion>
    {
        public QuaternionLerpActionAdapter(Quaternion a, Quaternion b, float t, Pointer<Quaternion> value) : base(a, b, t, value)
        { }

        public override ILerpAction Lerp()
        {
            Value._ = Quaternion.Lerp(A, B, T);
            return this;
        }
    }
}