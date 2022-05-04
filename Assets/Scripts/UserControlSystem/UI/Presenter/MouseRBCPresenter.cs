using Abstractions;
using System;
using UniRx;
using UnityEngine;
using Zenject;
using Abstractions.Commands;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem.UI.Presenter 
{
    public class MouseRBCPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsPresenter _commandButtonsPresenter;

        [Inject] private IObservable<ISelectable> _selectedValue;
        [Inject] private IObservable<IAttackable> _attakedValue;
        [Inject] private IObservable<Vector3> _Vector3Value;

        private ISelectable _currentSelectable;
        private ICommandsQueue _currentSelectableCommandsQueue;
        private bool _isAwaitCommand;
        private bool _commandIsPended = true;

        private void Start()
        {
            _selectedValue.Subscribe(ONSelected);
            _Vector3Value.Subscribe(ONCoordinateSelected);
            _attakedValue.Subscribe(ONEnemySelected);

            _commandButtonsPresenter.CommandButtonsModel.OnCommandSent += UnblockRBCActionsWithNewCommand;
            _commandButtonsPresenter.CommandButtonsModel.OnCommandCancel += UnblockRBCActions;
            _commandButtonsPresenter.CommandButtonsModel.OnCommandAccepted += BlockRBCActions;
        }

        private void UnblockRBCActionsWithNewCommand()
        {
            _isAwaitCommand = false;
            _commandIsPended = false;
        }

        private void UnblockRBCActions()
        {
            _isAwaitCommand = false;
            _commandIsPended = true;
        }

        private void BlockRBCActions(ICommandExecutor obj)
        {
            _isAwaitCommand = true;
            _commandIsPended = false;
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            if (selectable != null && (selectable as Component).TryGetComponent<ICommandsQueue>(out var queue))
            {
                _currentSelectableCommandsQueue = queue;
                _currentSelectable = selectable;
            } else
            {
                _currentSelectable = null;
                _currentSelectableCommandsQueue = null;
            }
        }

        private void ONCoordinateSelected(Vector3 target)
        {
            if (_isAwaitCommand || _currentSelectable is null)
            {
                return;
            }

            if (!_commandIsPended)
            {
                _commandIsPended = true;
                return;
            }

            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                _currentSelectableCommandsQueue.Clear();
            }
            _currentSelectableCommandsQueue.EnqueueCommand(new MoveCommand(target));
        }

        private void ONEnemySelected(IAttackable target)
        {
            if (_isAwaitCommand || _currentSelectable is null)
            {
                return;
            }

            if (!_commandIsPended)
            {
                _commandIsPended = true;
                return;
            }

            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                _currentSelectableCommandsQueue.Clear();
            }
            _currentSelectableCommandsQueue.EnqueueCommand(new AttackCommand(target));
        }
    }
}