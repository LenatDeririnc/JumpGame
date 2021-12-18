using Character.Animation.AnimationBehaviours.Pointer;
using Character.Animation.AnimationVariables;
using UnityEngine;

namespace Character.Animation.AnimationBehaviours
{
    public class GetUpState : BasePointerBehaviour
    {
        [SerializeField] private string GetUpBoolName = "PlayGetUp"; 
        
        protected override void OnPointerStateEnter()
        {
            _animator.SetBool(GetUpBoolName, false);
        }
    }
}