using Utils;
using UnityEngine;

public class UnitsRoot : MonoBehaviour
{
    [SerializeField] private AssetsContext _context;
    private void Awake()
    {
        _context.AddObject(this.gameObject);
    }
}
