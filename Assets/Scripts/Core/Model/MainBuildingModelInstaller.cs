using Zenject;

public class MainBuildingModelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Utils.PrefabInstantiator>().AsSingle().WithArguments(Container);
    }
}
