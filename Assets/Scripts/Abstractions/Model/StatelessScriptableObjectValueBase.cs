using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StatelessScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>
{
    private Subject<T> _data = new Subject<T>();
    public override void SetValue(T value)
    {
        base.SetValue(value);
        _data.OnNext(value);
    }
    public IDisposable Subscribe(IObserver<T> observer) =>
    _data.Subscribe(observer);
}
