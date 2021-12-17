using UnityEngine;

namespace Common.FollowManager.Lerp
{
    public abstract class FollowRotation : Follow<Quaternion>
    {
        public override Quaternion GetTransformValue() =>
            thisTransform.rotation;

        public override void SetTransformValue(Quaternion target) => 
            thisTransform.rotation = target;
    }
}