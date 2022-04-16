using UnityEngine;
using Utils;
using Zenject;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = "ScriptbleObjectsInstaller", menuName = "Installers/ScriptbleObjectsInstaller")]
    public class ScriptbleObjectsInstaller : ScriptableObjectInstaller<ScriptbleObjectsInstaller>
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _vector3Value;
        [SerializeField] private SelectableValue _selectableValue;
        [SerializeField] private SelectableEnemy _selectableEnemy;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3Value);
            Container.Bind<SelectableValue>().FromInstance(_selectableValue);
            Container.Bind<SelectableEnemy>().FromInstance(_selectableEnemy);
        }
    }
}