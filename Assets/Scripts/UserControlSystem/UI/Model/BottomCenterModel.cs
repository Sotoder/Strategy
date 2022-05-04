using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace UserControlSystem.UI.Model
{
    public sealed class BottomCenterModel
    {
        public IObservable<ITaskQueue> UnitProducers { get; private set; }

        [Inject]
        public void Init(IObservable<ISelectable> currentlySelected)
        {
            UnitProducers = currentlySelected
                .Select(selectable => selectable as Component)
                .Select(component => component?.GetComponent<ITaskQueue>());
        }
    }
}