using UnityEngine;

namespace Character.Animation.AnimationBehaviours.Pointer
{
    public abstract class BasePointerBehaviour : StateMachineBehaviour
    {
        protected CharacterController _characterController;

        protected Animator _animator;
        protected AnimatorStateInfo _stateInfo;
        protected int _layerIndex;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _characterController = CharacterController.Instance;
            _characterController.PointerBehaviourHandler.SetPointerBehaviour(this);

            _animator = animator;
            _stateInfo = stateInfo;
            _layerIndex = layerIndex;
            
            OnPointerStateEnter();
        }

        protected virtual void OnPointerStateEnter()
        { }

        public virtual void Action()
        { }
    }
}