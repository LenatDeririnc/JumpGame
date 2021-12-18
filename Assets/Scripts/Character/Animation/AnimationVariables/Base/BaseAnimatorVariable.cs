using Character.Animation.AnimationVariables.Base.Interfaces;
using UnityEngine;

namespace Character.Animation.AnimationVariables.Base
{
    public abstract class BaseAnimatorVariable : IAnimationName, IAnimatorHolder
    {
        protected Animator _animator;

        public Animator Animator => _animator;
        public abstract string Name { get; }

        public BaseAnimatorVariable(Animator animator = null) => 
            SetAnimator(animator);

        public void SetAnimator(Animator animator) => 
            _animator = animator;

        protected abstract void AnimatorAction();
    }
}