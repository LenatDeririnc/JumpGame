using UnityEngine;

namespace Character.Animation.AnimationVariables.Base.Interfaces
{
    public interface IAnimatorHolder
    {
        public Animator Animator { get; }
        public void SetAnimator(Animator animator);
    }
}