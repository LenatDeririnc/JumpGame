using System;
using System.Collections;
using UnityEngine;

namespace Common.CoroutineHelpers
{
    public class CoroutineWatcher
    {
        public Action OnCoroutineEnd;
        public bool IsPlaying => _isPlaying;
        
        private ICoroutineRunner _coroutineRunner;
        private Coroutine _watcher;
        private Coroutine _lastCoroutine;
        private bool _isPlaying = false;

        public CoroutineWatcher(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void StartCoroutine(IEnumerator coroutine) =>
            _watcher = _coroutineRunner.StartCoroutine(CoroutineCycle(coroutine));

        private IEnumerator CoroutineCycle(IEnumerator coroutine)
        {
            _isPlaying = true;
            yield return _lastCoroutine = _coroutineRunner.StartCoroutine(coroutine);

            _isPlaying = false;
            _watcher = null;
            _lastCoroutine = null;
            
            OnCoroutineEnd?.Invoke();
        }
        

        public void StopCoroutine()
        {
            if (_isPlaying && _watcher != null)
                _coroutineRunner.StopCoroutine(_watcher);
            
            if (_isPlaying && _lastCoroutine != null)
                _coroutineRunner.StopCoroutine(_lastCoroutine);

            _watcher = null;
            _lastCoroutine = null;
            _isPlaying = false;
        }
    }
}