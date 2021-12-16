using Character.Animation.AnimationVariables;
using UnityEngine;

namespace Character.Animation
{
    public class AnimationSwitcher : MonoBehaviour
    {
        [SerializeField] private AnimationTriggerObject defaultTrigger;
        
        private Animator _switcher;

        private void Awake() => 
            _switcher = GetComponent<Animator>();

        private void Start() => 
            _switcher.SetTrigger(defaultTrigger.TriggerName);

        public void SetTrigger(IAnimationTrigger trigger) 
            => _switcher.SetTrigger(trigger.TriggerName);

        public void SetBool(IAnimationBool boolClass)
            => _switcher.SetBool(boolClass.BoolName, boolClass.BoolValue);
    }
}