using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands.CommandsInterfaces;
using Abstractions.Executors;
using Zenject;
using UnityEngine;
using Abstractions;

namespace Core.CommandExecutors
{
    public class GrinaderHPUpgradeCommandExecutor : UpgradeHPCommandExecutor<IGrinaderUpgradeCommand>
    {
    }
}