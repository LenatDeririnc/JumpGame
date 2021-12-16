using Character.Animation.AnimationStates;

namespace Character.StateMachine
{
    public class JumpState : ICharacterState
    {
        public const string CLASS_NAME = "JumpState";
        private const string JUMP_VALUE = "Jump";
        
        private readonly CharacterStateMachine _stateMachine;
        private readonly CharacterController _controller;

        public JumpState(CharacterStateMachine stateMachine, CharacterController controller)
        {
            _stateMachine = stateMachine;
            _controller = controller;
        }
        
        public void OnEnter()
        {
            _controller.AnimationSwitcher.SetTrigger(new AnimationTrigger(JUMP_VALUE));
            _controller.GravityCalculator.currentFallingSpeed = -_controller.JumpHeight;
            _controller.GravityCalculator.UpdateMove();
            _controller.IsGroundedChecker.ONChange += isGrounded =>
            {
                if (isGrounded)
                    _stateMachine.Enter(ReadyForJumpState.CLASS_NAME);
            };
        }

        public override string ToString() => 
            CLASS_NAME;
    }
}