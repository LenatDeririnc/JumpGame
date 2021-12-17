using System;
using Common.CharpHelpers;
using UnityEngine;

namespace Common.FollowManager.Lerp
{
    public enum DeltaTimeType
    {
        None,
        DeltaTime,
        FixedDeltaTime
    }
    
    public abstract class Follow<T> : FollowManager.Follow<T>
    {
        [Space]
        [SerializeField] protected bool useLerp = true;
        [SerializeField] protected float lerpValue = 10f;
        [SerializeField] protected DeltaTimeType deltaTimeType;

        private Pointer<T> _refValue;

        protected Pointer<T> RefValue
        {
            get
            {
                _refValue ??= new Pointer<T>(FollowTargetValue(), SetTransformValue, GetTransformValue);
                return _refValue;
            }
        }
        
        protected float SelectedTime
        {
            get
            {
                float time = deltaTimeType switch
                {
                    DeltaTimeType.None => 1,
                    DeltaTimeType.DeltaTime => Time.deltaTime,
                    DeltaTimeType.FixedDeltaTime => Time.fixedDeltaTime,
                    _ => throw new ArgumentOutOfRangeException()
                };
                return time;
            }
        }

        protected override void FollowFunction()
        {
            if (!useLerp)
            {
                SetTransformValue(FollowTargetValue());
                return;
            }

            LerpFunction();
        }

        protected abstract void LerpFunction();
    }
}