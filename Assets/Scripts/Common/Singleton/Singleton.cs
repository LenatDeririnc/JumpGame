using System;
using UnityEngine;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using Common.DebugHelpers;
#endif

namespace Common.Singleton
{
    [Flags]
    public enum SingletonSettings
    {
        DestroyWithGameObject = 2^0,
        DestroyOnLoadScene = 2^1
    }
    
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance => _instance;
        
        private static Action<T> ONLoad;
        
        private static int InstanceCount = 0;

        private static SingletonSettings _flags;

        private static T _instance;

        private Object _destroyObject;
        
        protected virtual void BeforeAwake() 
        {}

        protected void SetSettings(SingletonSettings flags) => 
            _flags = flags;
        
        private void Awake()
        {
            BeforeAwake();

#if UNITY_EDITOR
            DebugContainers.InfiniteCycle(ref InstanceCount, 100);
#endif
            
            _destroyObject = _flags.HasFlag(SingletonSettings.DestroyWithGameObject) ? (Object) gameObject : this;
            
            if (_instance != null)
            {
                Destroy(_destroyObject);
                return;
            }

            _instance = this as T;

            if (!_flags.HasFlag(SingletonSettings.DestroyOnLoadScene))
                DontDestroyYourself();
            
            ONLoad?.Invoke(_instance);
            ONLoad = null;

            AfterAwake();
        }

        protected virtual void AfterAwake() 
        {}

        public static void CreateInstance()
        {
            GameObject singleton = new GameObject();
            _instance = singleton.AddComponent<T>();
            singleton.name = "(Created Singleton) " + typeof(T).ToString();
        }

        public static void ActionWithLoad(Action<T> action)
        {
            if (Instance != null)
                action(Instance);
            else
                ONLoad += action;
        }

        private void DontDestroyYourself()
        {
            transform.parent = null;
            DontDestroyOnLoad(this);
        }
    }
}