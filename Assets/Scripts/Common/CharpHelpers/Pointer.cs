using System;

namespace Common.CharpHelpers
{
    public class Pointer<T> 
    {
        private T _value;

        private readonly Action<T> _setAction;
        private readonly Func<T> _getAction;

        public T _
        {
            get
            {
                if (_getAction != null)
                    _value = _getAction();
                return _value;
            }
            set
            {
                _value = value;
                _setAction?.Invoke(_value);
            }
        }

        public Pointer(T reference, Action<T> setAction = null, Func<T> getAction = null)
        {
            _ = reference;
            _setAction = setAction;
            _getAction = getAction;
        }
    }
}