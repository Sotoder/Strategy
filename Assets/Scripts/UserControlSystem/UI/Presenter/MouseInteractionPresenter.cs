using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using Utils;
using Zenject;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;
    
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;

    //[Inject] private CommandCreatorBase<IMoveCommand> _mover;
    //[Inject] private AssetsContext _context;
    //private CommandExecutorBase<IMoveCommand> _moveExecutor;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
        //_groundClicksRMB.OnNewValue += ExecuteMove;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        if (Input.GetMouseButtonUp(0))
        {
            if (WeHit<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
            else
            {
                _selectedObject.SetValue(null);
            }
        }
        else
        {
            if (WeHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
    }

    private bool WeHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }    
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .FirstOrDefault(c => c != null);
        return result != default;
    }

    //private void ExecuteMove(Vector3 obj)
    //{
    //    if (_selectedObject.CurrentValue != null)
    //    {
    //        var commandExecutors = new List<ICommandExecutor>();
    //        commandExecutors.AddRange((_selectedObject.CurrentValue as Component).GetComponentsInParent<ICommandExecutor>());

    //        foreach (var executor in commandExecutors)
    //        {
    //            if (typeof(CommandExecutorBase<IMoveCommand>).IsAssignableFrom(executor.GetType()))
    //            {
    //                _mover.ProcessCommandExecutor(executor, command => executor.ExecuteCommand(command));
    //            }
    //        }
    //    }
    //}
}