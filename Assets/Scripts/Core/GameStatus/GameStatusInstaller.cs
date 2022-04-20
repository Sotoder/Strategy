using UnityEngine;
using Zenject;

namespace Core
{
    public class GameStatusInstaller : MonoInstaller
    {
        [SerializeField] private GameStatusModel _gameStatusmodel;
        [SerializeField] private GameStatus _gameStatus;
        public override void InstallBindings()
        {
            Container.Bind<GameStatusModel>().FromInstance(_gameStatusmodel);
            Container.BindInterfacesAndSelfTo<GameStatus>().FromInstance(_gameStatus);
        }
    }
}
