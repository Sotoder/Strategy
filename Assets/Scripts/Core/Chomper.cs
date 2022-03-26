using Abstractions;
using Abstractions.Commands;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Chomper : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Outline ObjectOutline => _outline;
    public List<ICommandExecutor> CommandExecutorsList => _commandExecutorsList;

    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Sprite _icon;
    [SerializeField] private CommandExecutorsListConfig _commandExecutorsConfig;

    private List<ICommandExecutor> _commandExecutorsList = new List<ICommandExecutor>();

    private float _health = 100;
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
        _commandExecutorsList = _commandExecutorsConfig.GetCommandExecutorsList();
    }
}
