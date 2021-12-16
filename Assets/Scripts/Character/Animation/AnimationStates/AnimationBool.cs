namespace Character.Animation.AnimationStates
{
    public class AnimationBool : IAnimationBool
    {
        private string _boolName;
        private bool _value;
        
        public AnimationBool(string name, bool value)
        {
            _boolName = name;
            _value = value;
        }

        public string BoolName => _boolName;
        public bool BoolValue
        {
            get => _value;
            set => _value = value;
        }
    }
}