using Abstractions;
using Abstractions.Commands;
using System.Collections.Generic;

public interface ICommandExecutorsConfig
{
    List<ICommandExecutor> GetCommandExecutorsList(ISelectable selectableObject);
}
