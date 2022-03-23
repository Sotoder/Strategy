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
        public Action<IUnitProducer> OnCreateUnit;

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

            if (IsIUnitProducer(CurrentValue, out IUnitProducer building))
            {
                OnCreateUnit?.Invoke(building); 
            }
        }

        private bool IsIUnitProducer(ISelectable selectable, out IUnitProducer building)
        {
            if(selectable is null)
            {
                building = null;
                return false;
            }

            if (selectable is IUnitProducer) // Cast is bad, can we do it without cast?
            {
                building = selectable as IUnitProducer;
                return true;
            }

            building = null;
            return false;
        }
    }
}