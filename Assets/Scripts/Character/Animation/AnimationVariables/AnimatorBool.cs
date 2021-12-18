using Character.Animation.AnimationVariables.Base;
using Character.Animation.AnimationVariables.Base.Interfaces;
using UnityEngine;

namespace Character.Animation.AnimationVariables
{
    public class AnimatorBool : BaseAnimatorVariable, IAnimationSetValue<bool>
    {
        private string _boolName;
        private bool _value;
        
        public AnimatorBool(string name, bool value, Animator animator = null) : base(animator)
        {
            _boolName = name;
            _value = value;
            SetAnimator(animator);
            AnimatorAction();
        }

        public override string Name 
            => _boolName;

        protected sealed override void AnimatorAction()
        {
            if (_animator != null)
                _animator.SetBool(Name, Value);
        }

        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                AnimatorAction();
            }
        }
    }
}