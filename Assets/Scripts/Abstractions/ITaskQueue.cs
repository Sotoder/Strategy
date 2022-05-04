using UniRx;

namespace Abstractions
{
    public interface ITaskQueue
    {
        IReadOnlyReactiveCollection<ITask> Queue { get; }
        int MaximumUnitsInQueue { get; }
        public void Cancel(int index);
        int Count();
        public ITask this[int index] { get; }
        void Add(ITask task);
    }
}