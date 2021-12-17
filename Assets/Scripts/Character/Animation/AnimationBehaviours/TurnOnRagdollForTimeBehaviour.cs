using Common.CoroutineHelpers.Timer;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class TurnOnRagdollForTimeBehaviour : StateMachineBehaviour
    {
        private const float TimeOfFall = 0.25f;
        private const float TimeOfState = 2f;
        
        private Timer _riseTimer;
        private Timer _fallingTimer;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _fallingTimer = 
                new Timer(
                    CharacterController.Instance, 
                    TimeOfFall, 
                    () => OnFallTimerEnd(animator, stateInfo, layerIndex));
            _fallingTimer.Start();
        }

        private void OnFallTimerEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.enabled = false;
            
            _riseTimer = 
                new Timer(
                    CharacterController.Instance, 
                    TimeOfState, 
                    () => OnRiseTimerEnd(animator, stateInfo, layerIndex));
            _riseTimer.Start();
        }
        
        private void OnRiseTimerEnd(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.enabled = true;
            animator.Play("Getting Up");
        }
    }
}