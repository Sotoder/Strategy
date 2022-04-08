using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UserControlSystem;
using Utils;

public class StatelessScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>, IAwaitable<T>
{
    private Subject<T> _data = new Subject<T>();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _data.OnNext(value);
    }
    public IDisposable Subscribe(IObserver<T> observer) =>
    _data.Subscribe(observer);

    public IAwaiter<T> GetAwaiter()
    {
        return new NewValueNotifier<T>(this);
    }
}
