using UnityEngine;

namespace Common.FollowManager
{
    public enum UpdateType
    {
        Update,
        FixedUpdate,
        LateUpdate
    }
    
    public abstract class Follow<T> : MonoBehaviour
    {
        [SerializeField] protected UpdateType updateType;
        [Space]
        [SerializeField] protected bool setPositionFromStart = false;

        protected Transform thisTransform;

        protected abstract T FollowTargetValue();
        protected abstract void FollowFunction();
        protected abstract bool IsTargetNull();
        public abstract void SetTransformValue(T target);
        public abstract T GetTransformValue();

        protected virtual void Awake() => 
            thisTransform = transform;

        private void Start()
        {
            if (setPositionFromStart && !IsTargetNull())
                SetTransformValue(FollowTargetValue());
        }

        private void UpdateTransform()
        {
            if (IsTargetNull())
                return;

            FollowFunction();
        }

        private void Update()
        {
            if (updateType != UpdateType.Update)
                return;

            UpdateTransform();
        }

        private void FixedUpdate()
        {
            if (updateType != UpdateType.FixedUpdate)
                return;

            UpdateTransform();
        }

        private void LateUpdate()
        {
            if (updateType != UpdateType.LateUpdate)
                return;

            UpdateTransform();
        }
    }
}