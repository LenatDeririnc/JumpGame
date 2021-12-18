using System;
using Character.Animation.AnimationBehaviours.Pointer;
using Character.Animation.AnimationVariables;
using Common;
using Common.CoroutineHelpers;
using Common.Singleton;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Character
{
    public class CharacterController : Singleton<CharacterController>, IUpdater, IFixedUpdater, ICoroutineRunner
    {
        [SerializeField] private UnityEngine.CharacterController _characterController;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _mass;
        [SerializeField] private RagdollHelper _ragdollHelper;
        [SerializeField] private Animator _animator;
        [SerializeField] private string GroundedAnimatorBoolName = "isGrounded";
        private AnimatorBool _groundedAnimationBool;
        private GravityCalculator _gravityCalculator;
        private BoolUpdateChecker _isGroundedChecker;
        private PointerBehaviourHandler _pointerBehaviourHandler;

        public Animator Animator => _animator;
        public UnityEngine.CharacterController UnityCharacterController => _characterController;
        public float JumpHeight => _jumpHeight;
        public float Mass => _mass;
        public GravityCalculator GravityCalculator => _gravityCalculator;

        public Action UPDATE { get; set; }
        public Action FIXED_UPDATE { get; set; }
        public BoolUpdateChecker IsGroundedChecker => _isGroundedChecker;
        public RagdollHelper RagdollHelper => _ragdollHelper;
        public PointerBehaviourHandler PointerBehaviourHandler => _pointerBehaviourHandler;
        
        protected override void BeforeAwake() => 
            SetSettings(SingletonSettings.DestroyOnLoadScene);

        protected override void AfterAwake()
        {
            _groundedAnimationBool = new AnimatorBool(GroundedAnimatorBoolName, _characterController.isGrounded, _animator);
            _isGroundedChecker = new BoolUpdateChecker(this, () => _characterController.isGrounded);
            _isGroundedChecker.ONChange += SetIsGrounded;
            _gravityCalculator = new GravityCalculator(this, _characterController, _mass, _isGroundedChecker);
            _pointerBehaviourHandler = new PointerBehaviourHandler();
        }

        private void SetIsGrounded(bool value) => 
            _groundedAnimationBool.Value = value;

        private void Start() => 
            SetIsGrounded(_characterController.isGrounded);

        private void Update() => 
            UPDATE?.Invoke();

        private void FixedUpdate() => 
            FIXED_UPDATE?.Invoke();

        public void OnPointerDown()
        {
            var pointer = _pointerBehaviourHandler.GetPointerBehaviour() as IPointerDown;
            pointer?.OnPointerDown();
        }

        public void OnPointerUp()
        {
            var pointer = _pointerBehaviourHandler.GetPointerBehaviour() as IPointerUp;
            pointer?.OnPointerUp();
        }
    }
}