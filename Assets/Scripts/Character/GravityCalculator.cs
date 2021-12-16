using Common;
using UnityEngine;

namespace Character
{
    public class GravityCalculator
    {
        private readonly UnityEngine.CharacterController _controller;
        private readonly float _mass;
        private readonly BoolUpdateChecker _isGroundedChecker;
        public float currentFallingSpeed;

        public GravityCalculator(IFixedUpdater updater, UnityEngine.CharacterController controller, float mass, BoolUpdateChecker isGroundedChecker)
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
}