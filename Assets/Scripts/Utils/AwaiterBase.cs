using System;

namespace Utils
{
    public abstract class AwaiterBase<T> : IAwaiter<T>
    {
        protected bool _isCompleted;
        protected Action _continuation;

        public bool IsCompleted => _isCompleted;

        public abstract T GetResult();

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
    }
}