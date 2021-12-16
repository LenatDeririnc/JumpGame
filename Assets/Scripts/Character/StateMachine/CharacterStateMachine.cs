using System.Collections.Generic;
using Character.StateMachine.States;

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
            AddState(new WaitForSafeLand(this, controller));
        }

        private void AddState(ICharacterState state)
        {
            _states[state.ToString()] = state;
        }

        public void Enter(string stateName)
        {
            CurrentState = _states[stateName];
            CurrentState.OnEnter();
        }
    }
}