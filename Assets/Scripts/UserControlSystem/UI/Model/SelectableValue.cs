using System;
using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public Action<ISelectable> OnSelected;
        public Action<ISelectable> OnUnselected;

        private ISelectable _lastValue;

        public void SetValue(ISelectable value)
        {
            CurrentValue = value;

            if (_lastValue != CurrentValue)
            {
                OnSelected?.Invoke(CurrentValue);
                OnUnselected?.Invoke(_lastValue);
                _lastValue = CurrentValue;
            }
        }
    }
}