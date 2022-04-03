using UnityEngine;
using Zenject;

namespace Utils
{
    public class PrefabInstantiator
    {
        private DiContainer _container;

        public PrefabInstantiator(DiContainer diContainer)
        {
            _container = diContainer;
        }

        public GameObject InstantiatePrefab(Object prefab)
        {
            return _container.InstantiatePrefab(prefab);
        }

        public GameObject InstantiatePrefab(Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform)
        {
            return _container.InstantiatePrefab(prefab, position, rotation, parentTransform);
        }

        public GameObject InstantiatePrefab(Object prefab, Transform parentTransform)
        {
            return _container.InstantiatePrefab(prefab, parentTransform);
        }

        public GameObject InstantiatePrefab(Object prefab, GameObjectCreationParameters gameObjectBindInfo)
        {
            return _container.InstantiatePrefab(prefab, gameObjectBindInfo);
        }
    }
}
