using UnityEngine;

namespace Common.FollowManager.DotTween
{
    public abstract class FollowPosition : Follow<Vector3>
    {
        public override Vector3 GetTransformValue() =>
            thisTransform.position;

        public override void SetTransformValue(Vector3 target) => 
            thisTransform.position = target;
    }
}