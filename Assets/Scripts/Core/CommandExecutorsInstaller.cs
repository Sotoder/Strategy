using Abstractions.Commands;
using Zenject;

namespace Core
{
    public sealed class CommandExecutorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var executors = gameObject.GetComponentsInChildren<ICommandExecutor>();
            foreach (var executor in executors)
            {
                var targetType = executor.GetType();
                while (targetType != null)
                {
                    Container.Bind(targetType).FromInstance(executor);
                    targetType = targetType.BaseType;
                }
            }
        }
    }
}