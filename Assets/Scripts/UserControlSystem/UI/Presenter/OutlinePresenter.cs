using Abstractions;
using UserControlSystem;
using UnityEngine;

public class OutlinePresenter : MonoBehaviour
{
    //[SerializeField] private SelectableValue _selectedValue;

    //private void Start()
    //{
    //    _selectedValue.OnUnselected += UnselectLastBuilding;
    //    _selectedValue.OnSelected += SelectBuilding;
    //}

    //private void SelectBuilding(ISelectable target)
    //{
    //    if (target is null) return;
    //    target.ObjectOutline.EnableOutLine();
    //}

    //private void UnselectLastBuilding(ISelectable target)
    //{
    //    if (target is null) return;
    //    target.ObjectOutline.DisableOutline();
    //}

    //private void OnDestroy()
    //{
    //    _selectedValue.OnSelected -= SelectBuilding;
    //    _selectedValue.OnUnselected -= UnselectLastBuilding;
    //}
}
