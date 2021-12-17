using System.Linq;
using Common.Extensions;
using Common.LerpAdapter;
using UnityEngine;

namespace Common.FollowManager.Lerp
{
    public class LerpCenterOfTransformsFollow : Follow<Vector3>, ITargetSetter<Transform[]>
    {
        [SerializeField] private Transform[] transforms;
        [SerializeField] private Vector3 localOffset;

        protected override void LerpFunction() => 
            new Vector3LerpActionAdapter(RefValue._, FollowTargetValue(), SelectedTime * lerpValue, RefValue).Lerp();

        public override Vector3 GetTransformValue() => 
            thisTransform.position;

        protected override Vector3 FollowTargetValue() => 
            transforms.Center();

        public override void SetTransformValue(Vector3 target) => 
            thisTransform.position = target;

        protected override bool IsTargetNull()
        {
            var isNoNulls = transforms.Aggregate(true, (current, transf) => current && transf != null);
            return transforms.Length == 0 && isNoNulls;
        }

        public void SetTarget(Transform[] target) => 
            transforms = target;
    }
}