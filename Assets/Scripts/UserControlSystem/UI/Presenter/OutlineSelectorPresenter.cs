using Abstractions;
using UnityEngine;
using UserControlSystem;
using Zenject;

public class OutlineSelectorPresenter : MonoBehaviour
{
    [Inject] private SelectableValue _selectableValue;
    
    private OutlineSelector[] _outlineSelectors;
    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectableValue.OnValueChange += OnSelected;
    }

    private void OnSelected(ISelectable selectable)
    {
        var color = Color.green;

        if (_currentSelectable == selectable)
        {
            return;
        }
        

        SetSelected(_outlineSelectors, false, color);
        _outlineSelectors = null;

        if (selectable != null)
        {
            if (selectable.IsEnemy) color = Color.red;

            _outlineSelectors = (selectable as Component).GetComponentsInParent<OutlineSelector>();
            SetSelected(_outlineSelectors, true, color);
        }
        else
        {
            if (_outlineSelectors != null)
            {
                SetSelected(_outlineSelectors, false, color);
            }
        }
        
        _currentSelectable = selectable;
        
        static void SetSelected(OutlineSelector[] selectors, bool value, Color color)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetColor(color);
                    selectors[i].SetSelected(value);
                }
            }
        }
    }

}
