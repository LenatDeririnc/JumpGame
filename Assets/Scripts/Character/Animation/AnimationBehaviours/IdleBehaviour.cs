using Character.StateMachine.States;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class IdleBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var charStateMachine = CharacterController.Instance.StateMachine;
            
            if (charStateMachine == null)
                return;
            
            if (charStateMachine.CurrentState is ReadyForJumpState)
                return;
            
            charStateMachine.Enter(ReadyForJumpState.ClassName);
        }
    }
}