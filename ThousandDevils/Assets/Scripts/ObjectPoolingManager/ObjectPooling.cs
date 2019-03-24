using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObjectPoolingManager
{
    public class ObjectPooling
    {
        private List<PoolObject> _poolObjects;
        private GameObject _parentObject;

        public void Initialize(int count, PoolObject poolObject, GameObject parentObject)
        {
            _poolObjects = new List<PoolObject>();
            _parentObject = parentObject;

            for (int i = 0; i < count; i++)
                InstantiateObject(poolObject, _parentObject);
        }

        public PoolObject GetFromPool()
        {
            foreach (var poolObject in _poolObjects)
                if (poolObject.gameObject.activeInHierarchy == false)
                    return poolObject;

            InstantiateObject(_poolObjects[0], _parentObject);

            return _poolObjects[_poolObjects.Count - 1];
        }

        private void InstantiateObject(PoolObject poolObject, GameObject parentObject)
        {
            var gameObject = Object.Instantiate(poolObject.gameObject);

            gameObject.name = poolObject.name;

            gameObject.transform.SetParent(parentObject.transform);

            _poolObjects.Add(gameObject.GetComponent<PoolObject>());

            gameObject.SetActive(false);
        }
    }
}