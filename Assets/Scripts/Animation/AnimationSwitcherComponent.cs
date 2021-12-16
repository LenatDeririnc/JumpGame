using Animation.AnimationStates;
using UnityEngine;

namespace Animation
{
    public class AnimationSwitcherComponent : MonoBehaviour
    {
        [SerializeField] private AnimationStateObject _defaultState;
        
        private AnimationSwitcher _switcher;

        private void Awake() => 
            _switcher = new AnimationSwitcher(GetComponent<Animator>());

        private void Start() => 
            _switcher.Play(_defaultState);

        public void Play(IAnimationState state) 
            => _switcher.Play(state);
    }
}