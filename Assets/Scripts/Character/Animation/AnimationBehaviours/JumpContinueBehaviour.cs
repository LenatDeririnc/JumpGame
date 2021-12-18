using Character.Animation.AnimationBehaviours.Pointer;
using Character.Animation.AnimationVariables;
using Common.CoroutineHelpers.Timer;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class JumpContinueBehaviour : PointerUpBehaviour
    {
        [SerializeField] private string FailBoolName = "Fail";
        [SerializeField] private float waitTiming = 0.5f;
        
        private bool _isPressed;
        
        private Timer _pressTiming;

        private AnimatorBool _failState;

        protected override void OnPointerStateEnter()
        {
            _isPressed = false;
            _failState = new AnimatorBool(FailBoolName, true, _animator);
            _pressTiming = new Timer(_characterController, waitTiming, OnEndTimer);
        }

        public void OnEndTimer()
        {
            _failState.Value = true;
        }
        
        public override void Action()
        {
            if (_isPressed)
                return;
            _isPressed = true;
            _pressTiming.Start();
            _failState.Value = false;
        }
    }
}