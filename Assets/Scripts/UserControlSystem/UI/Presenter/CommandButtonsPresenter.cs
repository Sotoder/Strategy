using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);

            _view.OnClick += ONButtonClick;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var executorType = GetExecutorType(commandExecutor);

            switch (executorType)
            {
                case ExecutorTypes.Produce:
                    (commandExecutor as CommandExecutorBase<IProduceUnitCommand>).ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                    break;
                case ExecutorTypes.Move:
                    (commandExecutor as CommandExecutorBase<IMoveCommand>).ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                    break;
                case ExecutorTypes.Attack:
                    (commandExecutor as CommandExecutorBase<IAttackCommand>).ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                    break;
                case ExecutorTypes.Patrol:
                    (commandExecutor as CommandExecutorBase<IPatrolCommand>).ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                    break;
                case ExecutorTypes.Stop:
                    (commandExecutor as CommandExecutorBase<IStopCommand>).ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                    break;
                case ExecutorTypes.None:
                    throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            }
        }

        private ExecutorTypes GetExecutorType(ICommandExecutor commandExecutor)
        {
            Type currentBaseType = commandExecutor.GetType();
            Type lastBaseType = default;

            while (currentBaseType != typeof(MonoBehaviour))
            {
                lastBaseType = currentBaseType;
                currentBaseType = lastBaseType.BaseType;
            }
            
            //evade casts and play with BaseType
            if (lastBaseType == typeof(CommandExecutorBase<IProduceUnitCommand>)) return ExecutorTypes.Produce;
            else if (lastBaseType == typeof(CommandExecutorBase<IMoveCommand>)) return ExecutorTypes.Move;
            else if (lastBaseType == typeof(CommandExecutorBase<IAttackCommand>)) return ExecutorTypes.Attack;
            else if (lastBaseType == typeof(CommandExecutorBase<IPatrolCommand>)) return ExecutorTypes.Patrol;
            else if (lastBaseType == typeof(CommandExecutorBase<IStopCommand>)) return ExecutorTypes.Stop;
            else return ExecutorTypes.None;
        }
    }

    public enum ExecutorTypes
    {
        Produce = 0,
        Move = 1,
        Attack = 2,
        Patrol = 3,
        Stop = 4,
        None = 99
    }
}