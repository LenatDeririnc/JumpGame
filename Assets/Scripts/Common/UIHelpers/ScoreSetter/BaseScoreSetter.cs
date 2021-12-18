using System;
using Common.Singleton;
using UnityEngine;

namespace Common.UIHelpers.ScoreSetter
{
    public abstract class BaseScoreSetter : Singleton<BaseScoreSetter>
    {
        protected static int currentScore = 0;
        
        [SerializeField] protected int startScore = 0;

        public static Action<int> OnUpdateScore;
        
        public static int CurrentScore => currentScore;
        
        protected override void BeforeAwake() => 
            SetSettings(SingletonSettings.DestroyOnLoadScene);

        protected virtual void UpdateTextAction() => 
            UpdateText($"{CurrentScore}");

        public void SetCurrentScore(int value)
        {
            currentScore = value;
            OnUpdateScore?.Invoke(currentScore);
            UpdateTextAction();
        }

        public void AddScore(int value)
        {
            currentScore += value;
            OnUpdateScore?.Invoke(currentScore);
            UpdateTextAction();
        }

        private void Start() => 
            UpdateTextAction();

        protected abstract void UpdateText(string text);
    }
}