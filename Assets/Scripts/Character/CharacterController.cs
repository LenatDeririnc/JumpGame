using System;
using Character.Animation;
using Character.Animation.AnimationVariables;
using Character.StateMachine;
using Common;
using Common.CoroutineHelpers;
using Common.Singleton;
using UnityEngine;

namespace Character
{
    public class CharacterController : Singleton<CharacterController>, IUpdater, IFixedUpdater, ICoroutineRunner
    {
        [SerializeField] private AnimationSwitcher _switcher;
        [SerializeField] private AnimationBoolObject _groundedAnimationBool;
        [SerializeField] private UnityEngine.CharacterController _characterController;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _mass;
        private CharacterStateMachine _stateMachine;
        private GravityCalculator _gravityCalculator;
        private BoolUpdateChecker _isGroundedChecker;

        public AnimationSwitcher AnimationSwitcher => _switcher;
        public UnityEngine.CharacterController UnityCharacterController => _characterController;
        public float JumpHeight => _jumpHeight;
        public float Mass => _mass;
        public CharacterStateMachine StateMachine => _stateMachine;
        public GravityCalculator GravityCalculator => _gravityCalculator;

        public Action UPDATE { get; set; }
        public Action FIXED_UPDATE { get; set; }
        public BoolUpdateChecker IsGroundedChecker => _isGroundedChecker;
        
        protected override void BeforeAwake() => 
            SetSettings(SingletonSettings.DestroyOnLoadScene);

        protected override void AfterAwake()
        {
            _stateMachine = new CharacterStateMachine(this);
            _isGroundedChecker = new BoolUpdateChecker(this, () => _characterController.isGrounded);
            _isGroundedChecker.ONChange += SetIsGrounded;
            _gravityCalculator = new GravityCalculator(this, _characterController, _mass, _isGroundedChecker);
        }

        private void SetIsGrounded(bool value)
        {
            _groundedAnimationBool.BoolValue = value;
            _switcher.SetBool(_groundedAnimationBool);
        }

        private void Start() => 
            SetIsGrounded(_characterController.isGrounded);

        private void Update() => 
            UPDATE?.Invoke();

        private void FixedUpdate() => 
            FIXED_UPDATE?.Invoke();

        public void OnPointerDown()
        {
            var pointer = _stateMachine.CurrentState as IPointerDown;
            pointer?.OnPointerDown();
        }

        public void OnPointerUp()
        {
            var pointer = _stateMachine.CurrentState as IPointerUp;
            pointer?.OnPointerUp();
        }
    }
}