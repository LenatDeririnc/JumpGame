using UnityEngine;

namespace Animation.AnimationStates
{
    [CreateAssetMenu(fileName = "Animation State", menuName = "Animation/Animation State", order = 1)]
    public class AnimationStateObject : ScriptableObject, IAnimationState
    {
        [SerializeField] private string triggerName;
        public string TriggerName => triggerName;
    }
}