using System;
using Character.Animation.AnimationVariables.Base;
using UnityEngine;

namespace Character.Animation.AnimationVariables
{
    public class AnimatorTrigger : BaseAnimatorVariable
    {
        private string _triggerName;

        public AnimatorTrigger(string triggerName, Animator animator = null) : base(animator) => 
            _triggerName = triggerName;

        public override string Name => _triggerName;
        protected override void AnimatorAction()
        {
            if (_animator != null)
                _animator.SetTrigger(Name);
        }

        public void Invoke()
        {
            AnimatorAction();
        }
    }
}