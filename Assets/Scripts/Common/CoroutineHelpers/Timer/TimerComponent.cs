using UnityEngine;
using UnityEngine.Events;

namespace Common.CoroutineHelpers.Timer
{
    public class TimerComponent : MonoBehaviour, ICoroutineRunner
    {
        private Timer _timer;
        [SerializeField] private bool playOnStart;
        [SerializeField] private float startSeconds;
        [SerializeField] private bool debugInfo = false;

        public UnityEvent OnEndTimer;

        private void Awake()
        {
            _timer = new Timer(this, startSeconds, InvokeAction, debugInfo, name);
        }

        private void InvokeAction()
        {
            OnEndTimer.Invoke();
        }

        private void Start()
        {
            if (playOnStart)
                Play();
        }

        public void Play()
        {
            _timer.Start();
        }

        public void Restart()
        {
            _timer.Restart();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void SetStartSeconds(float seconds)
        {
            _timer.SetStartSeconds(seconds);
        }

        public float CurrentTime() => _timer.CurrentTime;

        public bool IsEnabled() => _timer.IsEnabled;
    }
}