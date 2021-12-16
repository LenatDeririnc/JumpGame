using UnityEngine;

namespace Common.DebugHelpers
{
    public class FpsLocker : MonoBehaviour
    {
        [SerializeField] private int _targetFrameRate;
        
        private void Start()
        {
            Application.targetFrameRate = _targetFrameRate;
        }
    }
}