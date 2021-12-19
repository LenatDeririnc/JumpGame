using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class GetUpEnding : StateMachineBehaviour
    {
        public static bool GetUpEndingPlaying = false;

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetUpEndingPlaying = false;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            GetUpEndingPlaying = true;
        }
    }
}