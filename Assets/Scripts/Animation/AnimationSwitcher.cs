using Animation.AnimationStates;
using UnityEngine;

namespace Animation
{
    public class AnimationSwitcher
    {
        private Animator _animator;

        public AnimationSwitcher(Animator animator) => 
            _animator = animator;

        public void Play(IAnimationState state) => 
            _animator.SetTrigger($"{state.TriggerName}");
    }
}