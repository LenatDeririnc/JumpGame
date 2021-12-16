using UnityEngine;

namespace Character.Animation.AnimationStates
{
    [CreateAssetMenu(fileName = "Animation State", menuName = "Animation/Animation Bool State", order = 1)]
    public class AnimationBoolObject : ScriptableObject, IAnimationBool
    {
        [SerializeField] private string _boolName;
        [SerializeField] private bool _value;
        public string BoolName => _boolName;
        public bool BoolValue
        {
            get => _value;
            set => _value = value;
        }
    }
}