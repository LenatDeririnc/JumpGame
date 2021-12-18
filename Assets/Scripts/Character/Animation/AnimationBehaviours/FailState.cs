using Character.Animation.AnimationBehaviours.Pointer;
using Character.Animation.AnimationVariables;
using Common.CoroutineHelpers.Timer;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class FailState : BasePointerBehaviour
    {
        [SerializeField] private string GetUpBoolName = "GetUp";
        
        [SerializeField] private float TimeOfFail;
        [SerializeField] private float TimeOfState;

        private Timer _riseTimer;
        private Timer _fallingTimer;
        private RagdollHelper _helper;

        protected override void OnPointerStateEnter()
        {
            _helper = _characterController.RagdollHelper;
            
            _fallingTimer = 
                new Timer(
                    CharacterController.Instance, 
                    TimeOfFail,
                    OnFallTimerEnd);
            _fallingTimer.Start();
        }

        private void OnFallTimerEnd()
        {
            _helper.EnableRagdoll(true);
            
            _riseTimer = 
                new Timer(
                    CharacterController.Instance, 
                    TimeOfState, 
                    OnRiseTimerEnd);
            _riseTimer.Start();
        }
        
        private void OnRiseTimerEnd()
        {
            _helper.EnableRagdoll(false);
            _animator.SetTrigger(GetUpBoolName);
        }
    }
}