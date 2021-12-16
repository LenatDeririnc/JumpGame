using Character.StateMachine.States;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class WaitInputBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var charStateMachine = CharacterController.Instance.StateMachine;
            
            if (charStateMachine == null)
                return;
            
            if (charStateMachine.CurrentState is WaitForSafeLand)
                return;
            
            charStateMachine.Enter(WaitForSafeLand.ClassName);
        }
    }
}