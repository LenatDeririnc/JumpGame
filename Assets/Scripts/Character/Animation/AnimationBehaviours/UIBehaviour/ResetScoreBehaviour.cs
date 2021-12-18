using Common.UIHelpers.ScoreSetter;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours.UIBehaviour
{
    public class ResetScoreBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            BaseScoreSetter.Instance.SetCurrentScore(0);
        }
    }
}