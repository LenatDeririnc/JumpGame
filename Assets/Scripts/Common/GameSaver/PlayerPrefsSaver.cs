using System;
using UnityEngine;

namespace Common.GameSaver
{
    public class PlayerPrefsSaver<T> : ISaver<T> where T : struct
    {
        private readonly string _key;

        private Func<string, object> _playerPrefsActionGet;
        private Action<string, object> _playerPrefsActionSet;

        public PlayerPrefsSaver(string key, T defaultValue)
        {
            _key = key;
            SetPrefAction();

            if (IsNull()) 
                Set(defaultValue);
        }

        private void SetPrefAction()
        {
            switch (@Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Decimal:
                    _playerPrefsActionGet = key => PlayerPrefs.GetFloat(key); 
                    _playerPrefsActionSet = (key, value) => PlayerPrefs.SetFloat(key, (float) value);
                    break;
                
                case TypeCode.String:
                    _playerPrefsActionGet = key => PlayerPrefs.GetString(key);
                    _playerPrefsActionSet = (key, value) => PlayerPrefs.SetString(key, (string) value);
                    break;
                
                case TypeCode.Int16:
                    _playerPrefsActionGet = key => PlayerPrefs.GetInt(key);
                    _playerPrefsActionSet = (key, value) => PlayerPrefs.SetInt(key, (int) value);
                    break;
                
                case TypeCode.Int32:
                    _playerPrefsActionGet = key => PlayerPrefs.GetInt(key);
                    _playerPrefsActionSet = (key, value) => PlayerPrefs.SetInt(key, (int) value);
                    break;
                
                case TypeCode.Int64:
                    _playerPrefsActionGet = key => PlayerPrefs.GetInt(key);
                    _playerPrefsActionSet = (key, value) => PlayerPrefs.SetInt(key, (int) value);
                    break;
                
                case TypeCode.Boolean:
                    _playerPrefsActionGet = key => PlayerPrefs.GetInt(key) > 0;
                    _playerPrefsActionSet = (key, value) => PlayerPrefs.SetInt(key, Convert.ToInt32((bool) value));
                    break;
                
                default:
                    throw new Exception($"Can't set value for PlayerPrefs with value type: {typeof(T)}");
            }
        }

        public bool IsNull() => 
            !PlayerPrefs.HasKey(_key);

        public T Get() => 
            (T) _playerPrefsActionGet.Invoke(_key);

        public void Set(T value) => 
            _playerPrefsActionSet(_key, value);
    }
}