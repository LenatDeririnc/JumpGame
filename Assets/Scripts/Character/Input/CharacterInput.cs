using System;
using Character.Animation;
using Character.Animation.AnimationStates;
using Common;
using Common.Singleton;
using UnityEngine;

namespace Character.Input
{
    public class BoolUpdateChecker
    {
        private readonly Func<bool> _getParameter;
        private bool _currentValue = false;

        public Action<bool> ONChange;

        public BoolUpdateChecker(IUpdater updater, Func<bool> getParameter)
        {
            _getParameter = getParameter;
            _currentValue = _getParameter.Invoke();
            updater.UPDATE += Update;
        }

        private void Update()
        {
            if (_currentValue == _getParameter.Invoke()) 
                return;
            _currentValue = _getParameter.Invoke();
            ONChange?.Invoke(_currentValue);
        }
    }

    public class GravityCalculator
    {
        private readonly CharacterController _controller;
        private readonly float _mass;
        private readonly BoolUpdateChecker _isGroundedChecker;
        public float currentFallingSpeed;

        public GravityCalculator(IFixedUpdater updater, CharacterController controller, float mass, BoolUpdateChecker isGroundedChecker)
        {
            _controller = controller;
            _mass = mass;
            _isGroundedChecker = isGroundedChecker;
            _isGroundedChecker.ONChange += OnJumpStateChanged;
            
            updater.FIXED_UPDATE += Update;
        }

        private void Update()
        {
            if (_controller.isGrounded)
                return;
            
            currentFallingSpeed += Time.fixedDeltaTime * Time.fixedDeltaTime * Vector3.SqrMagnitude(Physics.gravity) * _mass;
            UpdateMove();
        }

        private void OnJumpStateChanged(bool isGrounded)
        {
            if (!isGrounded) 
                return;
            
            if (currentFallingSpeed != 0f)
                currentFallingSpeed = 0;
        }

        public Vector3 GetFallingVector() => 
            new Vector3(0,  -currentFallingSpeed, 0);

        public void UpdateMove()
        {
            _controller.Move(GetFallingVector());
        }
    }

    public class CharacterInput : Singleton<CharacterInput>, IUpdater, IFixedUpdater
    {
        [SerializeField] private AnimationSwitcher _switcher;
        [SerializeField] private AnimationTriggerObject _jumpTrigger;
        [SerializeField] private AnimationBoolObject _groundedAnimationBool;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _mass;

        private GravityCalculator _gravityCalculator;

        public Action UPDATE { get; set; }
        public Action FIXED_UPDATE { get; set; }


        protected override void BeforeAwake() => 
            SetSettings(SingletonSettings.DestroyOnLoadScene);

        protected override void AfterAwake()
        {
            var isGroundedChecker = new BoolUpdateChecker(this, () => _characterController.isGrounded);
            isGroundedChecker.ONChange += SetIsGrounded;
            _gravityCalculator = new GravityCalculator(this, _characterController, _mass, isGroundedChecker);
        }

        private void SetIsGrounded(bool value)
        {
            _groundedAnimationBool.BoolValue = value;
            _switcher.SetBool(_groundedAnimationBool);
        }

        private void Start()
        {
            SetIsGrounded(_characterController.isGrounded);
        }

        private void Update() => 
            UPDATE?.Invoke();

        private void FixedUpdate() => 
            FIXED_UPDATE?.Invoke();

        public void Jump()
        {
            _switcher.SetTrigger(_jumpTrigger);
            _gravityCalculator.currentFallingSpeed = -_jumpHeight;
            _gravityCalculator.UpdateMove();
        }
    }
}