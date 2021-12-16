using UnityEngine;

namespace Character.Animation.AnimationVariables
{
    [CreateAssetMenu(fileName = "Animation Bool State", menuName = "Animation/AnimationBoolState", order = 2)]
    public class AnimationBoolObject : ScriptableObject, IAnimationBool
    {
        [SerializeField] private string _boolName;
        [SerializeField] private bool _value;

        private IAnimationBool subclass;
        
        private void OnEnable()
        {
            subclass = new AnimationBool(_boolName, _value);
        }

        public string BoolName => subclass.BoolName;
        public bool BoolValue
        {
            get => subclass.BoolValue;
            set => subclass.BoolValue = value;
        }
    }
}