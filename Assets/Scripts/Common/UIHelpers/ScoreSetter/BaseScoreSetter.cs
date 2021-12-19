using System;
using Common.GameSaver;
using Common.Singleton;
using UnityEngine;

namespace Common.UIHelpers.ScoreSetter
{
    public abstract class BaseScoreSetter : Singleton<BaseScoreSetter>
    {
        protected const string ScorePrefsName = "Score";
        
        [SerializeField] bool SaveScore = true;
        private ISaver<int> scoreSave;

        protected static int currentScore = 0;
        
        [SerializeField] protected int startScore = 0;

        public static Action<int> OnUpdateScore;
        
        public static int CurrentScore => currentScore;
        
        protected override void BeforeAwake() => 
            SetSettings(SingletonSettings.DestroyOnLoadScene);

        protected override void AfterAwake()
        {
            scoreSave = new PlayerPrefsSaver<int>(ScorePrefsName, currentScore);
            
            if (SaveScore)
                currentScore = scoreSave.Get();
        }

        protected virtual void UpdateTextAction() => 
            UpdateText($"{CurrentScore}");

        private void SaveCurrentScore()
        {
            if (SaveScore)
                scoreSave.Set(currentScore);
        }
        
        public void SetCurrentScore(int value)
        {
            currentScore = value;
            OnUpdateScore?.Invoke(currentScore);
            SaveCurrentScore();
            UpdateTextAction();
        }

        public void AddScore(int value)
        {
            currentScore += value;
            OnUpdateScore?.Invoke(currentScore);
            SaveCurrentScore();
            UpdateTextAction();
        }

        private void Start() => 
            UpdateTextAction();

        protected abstract void UpdateText(string text);
    }
}