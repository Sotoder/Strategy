using System;
using Utils;

public abstract class BaseAwaiter<T> : IAwaiter<T>
{
    protected IDisposable _statefulSubscribtion;
    protected IDisposable _statelessSubscribtion;

    protected bool _isStateless;

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

    protected virtual void ONNewValue(T arg)
    {
        if (_isStateless) _statelessSubscribtion.Dispose();
        else _statefulSubscribtion.Dispose();
        _isCompleted = true;
        _continuation?.Invoke();
    }
}
