using Abstractions;
using UserControlSystem;
using UnityEngine;

public class BuildingsControlPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;

    private void Start()
    {
        _selectedValue.OnCreateUnit += CreateUnit;
        _selectedValue.OnUnselected += UnselectLastBuilding;
        _selectedValue.OnSelected += SelectBuilding;
    }

    private void SelectBuilding(ISelectable target)
    {
        if (target is null) return;
        target.ObjectOutline.EnableOutLine();
    }

    private void UnselectLastBuilding(ISelectable target)
    {
        if (target is null) return;
        target.ObjectOutline.DisableOutline();
    }

    private void CreateUnit(IUnitProducer building)
    {
        building.ProduceUnit();
    }

    private void OnDestroy()
    {
        _selectedValue.OnCreateUnit -= CreateUnit;
        _selectedValue.OnSelected -= SelectBuilding;
        _selectedValue.OnUnselected -= UnselectLastBuilding;
    }
}
