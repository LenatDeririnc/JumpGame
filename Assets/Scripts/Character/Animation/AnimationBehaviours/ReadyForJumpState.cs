using Character.Animation.AnimationBehaviours.Pointer;
using Character.Animation.AnimationVariables;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class ReadyForJumpState : PointerDownBehaviour
    {
        [SerializeField] private string JumpTriggerName;

        public override void Action()
        {
            _animator.SetTrigger(JumpTriggerName);
            _characterController.GravityCalculator.currentFallingSpeed = - _characterController.JumpHeight;
            _characterController.GravityCalculator.UpdateMove();
        }
    }
}