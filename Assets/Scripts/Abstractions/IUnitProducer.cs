using UniRx;
using UnityEngine;

namespace Abstractions
{
    public interface IUnitProducer
    {
        IReadOnlyReactiveCollection<IUnitProductionTask> Queue { get; }
        public void Cancel(int index);
    }
}