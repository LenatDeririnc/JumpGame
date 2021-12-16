using System;
using UnityEngine;

namespace Character.Animation.AnimationStates
{
    [CreateAssetMenu(fileName = "Animation State", menuName = "Animation/Animation Trigger State", order = 1)]
    public class AnimationTriggerObject : ScriptableObject, IAnimationTrigger
    {
        [SerializeField] private string triggerName;

        private IAnimationTrigger subclass;

        private void OnValidate()
        {
            subclass = new AnimationTrigger(triggerName);
        }

        public string TriggerName => subclass.TriggerName;
    }
}