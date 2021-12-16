using System.Collections.Generic;

namespace Character.StateMachine
{
    public class CharacterStateMachine
    {
        private Dictionary<string, ICharacterState> _states;
        public ICharacterState CurrentState { get; private set; }

        public CharacterStateMachine(CharacterController controller)
        {
            _states = new Dictionary<string, ICharacterState>();
            
            AddState(new ReadyForJumpState(this, controller));
            AddState(new JumpState(this, controller));
            
            Enter(ReadyForJumpState.CLASS_NAME);
        }

        private void AddState(ICharacterState state)
        {
            _states[state.ToString()] = state;
        }

        public void Enter(string StateName)
        {
            CurrentState = _states[StateName];
            CurrentState.OnEnter();
        }
    }
}