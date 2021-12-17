using Common.LerpAdapter;
using UnityEngine;

namespace Common.FollowManager.Lerp
{
    public class LerpRotationFollow : FollowRotation, ITargetSetter<Transform>
    {
        [SerializeField] private Transform _followObject;

        protected override void LerpFunction() => 
            new QuaternionLerpActionAdapter(RefValue._, FollowTargetValue(), SelectedTime * lerpValue, RefValue).Lerp();

        protected override Quaternion FollowTargetValue() => 
            _followObject.rotation;

        protected override bool IsTargetNull() => 
            _followObject == null;

        public void SetTarget(Transform target) => 
            _followObject = target;
    }
}