using Common.LerpAdapter;
using UnityEngine;

namespace Common.FollowManager.Lerp
{
    public class LerpObjectFollow : FollowPosition, ITargetSetter<Transform>
    {
        [SerializeField] private Transform _followObject;

        protected override void LerpFunction() => 
            new Vector3LerpActionAdapter(RefValue._, FollowTargetValue(), SelectedTime * lerpValue, RefValue).Lerp();

        protected override Vector3 FollowTargetValue() => 
            _followObject.position;

        protected override bool IsTargetNull() => 
            _followObject == null;

        public void SetTarget(Transform target) => 
            _followObject = target;
    }
}