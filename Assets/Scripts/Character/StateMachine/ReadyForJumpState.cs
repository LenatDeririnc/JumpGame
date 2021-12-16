namespace Character.StateMachine
{
    public class ReadyForJumpState : ICharacterState, IPointerDown
    {
        public const string CLASS_NAME = "ReadyForJumpState";
        
        private readonly CharacterStateMachine _stateMachine;
        private readonly CharacterController _controller;

        public ReadyForJumpState(CharacterStateMachine stateMachine, CharacterController controller)
        {
            _stateMachine = stateMachine;
            _controller = controller;
        }

        public void OnEnter()
        { }

        public void OnPointerDown()
        {
            _stateMachine.Enter(JumpState.CLASS_NAME);
        }

        public override string ToString() => 
            CLASS_NAME;
    }
}