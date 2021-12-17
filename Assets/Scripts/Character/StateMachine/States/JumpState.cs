using Character.Animation.AnimationVariables;

namespace Character.StateMachine.States
{
    public class JumpState : ICharacterState
    {
        public const string ClassName = "JumpState";
        private const string JumpValue = "Jump";
        
        private readonly CharacterController _controller;

        public JumpState(IStateMachineEnter stateMachine, CharacterController controller)
        {
            _controller = controller;
        }

        public override string ToString() => 
            ClassName;

        public void OnEnter()
        {
            _controller.AnimationSwitcher.SetTrigger(new AnimationTrigger(JumpValue));
            _controller.GravityCalculator.currentFallingSpeed = -_controller.JumpHeight;
            _controller.GravityCalculator.UpdateMove();
        }
    }
}