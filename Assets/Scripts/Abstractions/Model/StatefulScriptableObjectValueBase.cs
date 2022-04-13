using System;
using UniRx;

public class StatefulScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>
{
    private ReactiveProperty<T> _data = new ReactiveProperty<T>();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _data.Value = value;
    }
    public IDisposable Subscribe(IObserver<T> observer) => _data.Subscribe(observer);
}

