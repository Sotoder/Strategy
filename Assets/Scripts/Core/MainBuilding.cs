using Abstractions;
using Abstractions.Commands;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public sealed class MainBuilding : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public List<ICommandExecutor> CommandExecutorsList => _commandExecutorsList;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private CommandExecutorsListConfig _commandExecutorsConfig;

    private List<ICommandExecutor> _commandExecutorsList = new List<ICommandExecutor>();

    private float _health = 1000;

    private void Start()
    {
        _commandExecutorsList = _commandExecutorsConfig.GetCommandExecutorsList();
    }
}