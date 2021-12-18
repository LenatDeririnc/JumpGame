using Common.UIHelpers.ScoreSetter;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours.UIBehaviour
{
    public class IncreaseScoreBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            BaseScoreSetter.Instance.AddScore(1);
        }
    }
}