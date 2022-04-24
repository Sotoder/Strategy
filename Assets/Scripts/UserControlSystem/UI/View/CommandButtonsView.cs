﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {
        public Action<ICommandExecutor, ICommandsQueue> OnClick;

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _stopButton;
        [SerializeField] private GameObject _produceChomperButton;
        [SerializeField] private GameObject _produceGrinaderButton;
        [SerializeField] private GameObject _setRallyButton;
        [SerializeField] private GameObject _upgradeChomperHPButton;
        [SerializeField] private GameObject _upgradeGrinaderHPButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IAttackCommand>), _attackButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IMoveCommand>), _moveButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IStopCommand>), _stopButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IProduceChomperCommand>), _produceChomperButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IProduceGrinaderCommand>), _produceGrinaderButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<ISetDistanationCommand>), _setRallyButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IChomperHPUpgradeCommand>), _upgradeChomperHPButton);
            _buttonsByExecutorType
                .Add(typeof(ICommandExecutor<IGrinaderHPUpgradeCommand>), _upgradeGrinaderHPButton);

            Clear();
        }
        public void BlockInteractions(ICommandExecutor ce)
        {
            UnblockAllInteractions();
            GETButtonGameObjectByType(ce.GetType())
                .GetComponent<Selectable>().interactable = false;
        }

        public void UnblockAllInteractions() => SetInteractible(true);

        private void SetInteractible(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _stopButton.GetComponent<Selectable>().interactable = value;
            _produceChomperButton.GetComponent<Selectable>().interactable = value;
            _produceGrinaderButton.GetComponent<Selectable>().interactable = value;
            _setRallyButton.GetComponent<Selectable>().interactable = value;
            _upgradeChomperHPButton.GetComponent<Selectable>().interactable = value;
            _upgradeGrinaderHPButton.GetComponent<Selectable>().interactable = value;
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors, ICommandsQueue queue)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = GETButtonGameObjectByType(currentExecutor.GetType());
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor, queue));
            }
        }

        private GameObject GETButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
                .First(type => type.Key.IsAssignableFrom(executorInstanceType))
                .Value;
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value
                    .GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }
    }
}