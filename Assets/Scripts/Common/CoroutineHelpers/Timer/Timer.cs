﻿using System;
using System.Collections;
using UnityEngine;

namespace Common.CoroutineHelpers.Timer
{
    public class Timer
    {
        public string name { get; }
        private float _currentTime;
        private readonly ICoroutineRunner _runner;
        private Coroutine _timerCoroutine;
        private readonly Action _callbackAction;
        private readonly bool _debugInfo;
        private float _startSeconds;

        private bool _isEnabled = false;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                
                if (value)
                    Start();
                else
                    Stop();
            }
        }

        public float CurrentTime => _currentTime;
        
        public Timer(ICoroutineRunner runner, float startSeconds, Action callbackAction, bool debugInfo = false, string name = "Timer")
        {
            this.name = name;
            _runner = runner;
            _callbackAction = callbackAction;
            _debugInfo = debugInfo;
            _currentTime = startSeconds;
            _startSeconds = startSeconds;
        }

        public void Start()
        {
            if (IsEnabled)
                return;

            _isEnabled = true;
            _timerCoroutine = _runner.StartCoroutine(TimerIEnumerator());
        }

        public void Stop()
        {
            if (!IsEnabled)
                return;
            
            _isEnabled = false;
            
            if (_timerCoroutine != null)
                _runner.StopCoroutine(_timerCoroutine);
            
            _timerCoroutine = null;
        }

        public void Reset()
        {
            Stop();
            _currentTime = _startSeconds;
        }

        public void Restart()
        {
            Reset();
            Start();
        }

        public void SetStartSeconds(float seconds)
        {
            _startSeconds = seconds;
        }

        public IEnumerator TimerIEnumerator()
        {
            while (IsEnabled && _currentTime > 0)
            {
                _currentTime -= Time.deltaTime;
                if (_debugInfo)
                    Debug.Log(ToString());
                yield return null;
            }

            if (IsEnabled)
                _callbackAction();
        }

        public override string ToString()
        {
            return $"{name}: {_currentTime}";
        }
    }
}