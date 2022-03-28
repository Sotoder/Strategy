using Abstractions;
using UserControlSystem;
using UnityEngine;
using Utils;

public class OutlinePresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;

    private void Start()
    {
        _selectedValue.OnUnselected += UnselectLastBuilding;
        _selectedValue.OnSelected += SelectBuilding;
    }

    private void SelectBuilding(ISelectable target)
    {
        if (target is null) return;
        if(target.gameObject.TryGetComponent<Outline>(out var outline))
        {
            outline.EnableOutLine(); 
        }
    }

    private void UnselectLastBuilding(ISelectable target)
    {
        if (target is null) return;
        if (target.gameObject.TryGetComponent<Outline>(out var outline))
        {
            outline.DisableOutline();
        }
    }

    private void OnDestroy()
    {
        _selectedValue.OnSelected -= SelectBuilding;
        _selectedValue.OnUnselected -= UnselectLastBuilding;
    }
}
