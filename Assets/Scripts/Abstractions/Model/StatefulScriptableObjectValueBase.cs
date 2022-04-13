using System;
using UniRx;
using UserControlSystem;
using Utils;

public class StatefulScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>, IAwaitable<T>
{
    private ReactiveProperty<T> _data = new ReactiveProperty<T>();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _data.Value = value;
    }
    public IDisposable Subscribe(IObserver<T> observer) => _data.Subscribe(observer);

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}

