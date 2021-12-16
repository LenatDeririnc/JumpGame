using System;

namespace Common
{
    public class BoolUpdateChecker
    {
        private readonly Func<bool> _getParameter;
        private bool _currentValue = false;

        public Action<bool> ONChange;

        public BoolUpdateChecker(IUpdater updater, Func<bool> getParameter)
        {
            _getParameter = getParameter;
            _currentValue = _getParameter.Invoke();
            updater.UPDATE += Update;
        }

        private void Update()
        {
            if (_currentValue == _getParameter.Invoke()) 
                return;
            _currentValue = _getParameter.Invoke();
            ONChange?.Invoke(_currentValue);
        }
    }
}