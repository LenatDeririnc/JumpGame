using Animation;
using Animation.AnimationStates;
using Common.Singleton;
using UnityEngine;

namespace Input
{
    public class CharacterInput : Singleton<CharacterInput>
    {
        [SerializeField] private AnimationSwitcherComponent _switcher;
        [SerializeField] private AnimationStateObject _jumpState;

        protected override void BeforeAwake() => 
            SetSettings(SingletonSettings.DestroyOnLoadScene);

        public void Jump()
        {
            _switcher.Play(_jumpState);
        }
    }
}