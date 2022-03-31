using UnityEngine;
using Utils;

namespace Abstractions
{
    public abstract class BaseUnit : MonoBehaviour
    {
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Outline ObjectOutline => _outline;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;

        private Outline _outline;

        private void Start()
        {
            _outline = gameObject.GetComponent<Outline>();
        }
    }
}