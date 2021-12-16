using System;
using UnityEngine;

namespace Character.Animation.AnimationVariables
{
    [CreateAssetMenu(fileName = "Animation Trigger State", menuName = "Animation/AnimationTriggerState", order = 1)]
    public class AnimationTriggerObject : ScriptableObject, IAnimationTrigger
    {
        [SerializeField] private string triggerName;

        private IAnimationTrigger subclass;

        private void OnEnable()
        {
            subclass = new AnimationTrigger(triggerName);
        }

        public string TriggerName => subclass.TriggerName;
    }
}