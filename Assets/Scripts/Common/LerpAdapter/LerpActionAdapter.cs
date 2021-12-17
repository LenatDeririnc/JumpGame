using Common.CharpHelpers;

namespace Common.LerpAdapter
{
    public abstract class LerpActionAdapter<TRef> : ILerpAction
    {
        protected readonly TRef A;
        protected readonly TRef B;
        protected readonly float T;
        protected readonly Pointer<TRef> Value;
        
        public LerpActionAdapter(TRef a, TRef b, float t, Pointer<TRef> value)
        {
            A = a;
            B = b;
            T = t;
            Value = value;
        }

        public abstract ILerpAction Lerp();
    }
}