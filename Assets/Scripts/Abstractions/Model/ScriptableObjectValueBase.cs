using System;
using UnityEngine;
using UserControlSystem;
using Utils;

public abstract class ScriptableObjectValueBase<T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;
    public virtual void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}
