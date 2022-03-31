using UnityEngine;
using Utils;

public sealed class OutlineSelector : MonoBehaviour
{
    [SerializeField] private Outline[] _outlineComponents;

    private bool _isSelectedCache;

    private void Start() => DisableOutline();
    
    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedCache)
        {
            return;
        }

        if (isSelected)
        {
            EnableOutline();
        }
        else
        {
            DisableOutline();
        }
        
        _isSelectedCache = isSelected;
    }

    public void SetColor(Color color)
    {
        for (int i = 0; i < _outlineComponents.Length; i++)
        {
            _outlineComponents[i].OutlineColor = color;
        }
    }

    private void DisableOutline()
    {
        for (int i = 0; i < _outlineComponents.Length; i++)
        {
            _outlineComponents[i].DisableOutline();
        }
    }

    private void EnableOutline()
    {
        for (int i = 0; i < _outlineComponents.Length; i++)
        {
            _outlineComponents[i].EnableOutLine();
        }
    }
}
