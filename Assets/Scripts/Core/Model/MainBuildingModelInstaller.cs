using UnityEngine;
using Zenject;

public class MainBuildingModelInstaller : MonoInstaller, IPrefabInstantiateInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPrefabInstantiateInstaller>().To<MainBuildingModelInstaller>().FromInstance(this);
    }

    public GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform)
    {
        return Container.InstantiatePrefab(prefab, position, rotation, parentTransform);
    }
}
