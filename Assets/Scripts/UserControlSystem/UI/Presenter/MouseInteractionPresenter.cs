using System.Linq;
using Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;
using Zenject;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;
    
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;
    
    private Plane _groundPlane;
    
    private void Start() => _groundPlane = new Plane(_groundTransform.up, 0);

    [Inject]
    public void Init()
    {
        var LMBClick = Observable.EveryUpdate().Where(click => Input.GetMouseButtonDown(0));
        var RMBClick = Observable.EveryUpdate().Where(click => Input.GetMouseButtonDown(1));

        var LMBHits = LMBClick.Select(rays => _camera.ScreenPointToRay(Input.mousePosition)).Select(ray => Physics.RaycastAll(ray));
        var RMBHits = RMBClick.Select(rays => _camera.ScreenPointToRay(Input.mousePosition));

        LMBHits.Subscribe(hits =>
        {
            if (WeHit<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        });

        RMBHits.Subscribe(ray =>
        {
            var hits = Physics.RaycastAll(ray);
            if (WeHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        });

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
}