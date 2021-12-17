using Character.Animation.AnimationVariables;
using Common;
using Common.CoroutineHelpers.Timer;

namespace Character.StateMachine.States
{
    public class WaitForSafeLand : ICharacterState, IPointerUp
    {
        public const string ClassName = "WaitForSafeLand";
        private const string FailAnimationName = "Fail";
        
        private const float WaitTime = 0.5f;
        
        private readonly IStateMachineEnter _stateMachine;
        private readonly CharacterController _controller;
        private readonly Timer _timer;

        private readonly AnimationBool _failBool;

        private bool _isPointeredUp = false;
        
        public WaitForSafeLand(IStateMachineEnter stateMachine, CharacterController controller)
        {
            _stateMachine = stateMachine;
            _controller = controller;
            _failBool = new AnimationBool(FailAnimationName, true);
            _timer = new Timer(controller, WaitTime, OnTimerEnd);
        }

        private void SetFail(bool value)
        {
            _failBool.BoolValue = value;
            _controller.AnimationSwitcher.SetBool(_failBool);
        }

        private void OnTimerEnd()
        {
            SetFail(true);
        }

        public void OnEnter()
        {
            _isPointeredUp = false;
            SetFail(true);
            _timer.Reset();
        }

        public void OnPointerUp()
        {
            if (_isPointeredUp)
                return;
            
            SetFail(false);
            _timer.Start();
            _isPointeredUp = true;
        }

        public override string ToString() => 
            ClassName;
    }
}