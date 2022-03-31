using System;
using UnityEngine;

public abstract class BaseModel<T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnValueChange;
    public void SetValue(T value)
    {
        CurrentValue = value;
        OnValueChange?.Invoke(value);
    }
}
