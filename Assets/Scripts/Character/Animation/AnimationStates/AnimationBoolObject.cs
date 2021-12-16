using UnityEngine;

namespace Character.Animation.AnimationStates
{
    [CreateAssetMenu(fileName = "Animation State", menuName = "Animation/Animation Bool State", order = 1)]
    public class AnimationBoolObject : ScriptableObject, IAnimationBool
    {
        [SerializeField] private string _boolName;
        [SerializeField] private bool _value;

        private IAnimationBool subclass;
        
        private void OnValidate() => 
            subclass = new AnimationBool(_boolName, _value);

        public string BoolName => subclass.BoolName;
        public bool BoolValue
        {
            get => subclass.BoolValue;
            set => subclass.BoolValue = value;
        }
    }
}