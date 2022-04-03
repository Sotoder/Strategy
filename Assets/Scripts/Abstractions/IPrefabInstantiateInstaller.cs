using UnityEngine;

public interface IPrefabInstantiateInstaller
{
    public GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform);
}
