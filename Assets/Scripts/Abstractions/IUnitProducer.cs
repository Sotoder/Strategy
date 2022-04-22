using UniRx;

namespace Abstractions
{
    public interface IUnitProducer
    {
        IReadOnlyReactiveCollection<IUnitProductionTask> Queue { get; }
        int MaximumUnitsInQueue { get; }
        public void Cancel(int index);
        int Count();
        public IUnitProductionTask this[int index] { get; }
        void Add(IUnitProductionTask task);
    }
}