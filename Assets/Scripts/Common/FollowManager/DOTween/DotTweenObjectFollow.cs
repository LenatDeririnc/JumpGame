using DG.Tweening;
using UnityEngine;

namespace Common.FollowManager.DotTween
{
    public class DotTweenObjectFollow : FollowPosition, ITargetSetter<Transform>
    {
        [Space]
        [SerializeField] private Transform _target;
        [SerializeField] public float duration = 2;
        [SerializeField] public bool speedBased = false;
        [SerializeField] public Ease ease;
        
        protected override Vector3 FollowTargetValue() => 
            _target.position;

        protected override void FollowFunction() =>
            thisTransform.DOMove(FollowTargetValue(), duration)
                .SetSpeedBased(speedBased)
                .SetEase(ease);

        protected override bool IsTargetNull() => 
            _target == null;

        public void SetTarget(Transform target) => 
            _target = target;
    }
}