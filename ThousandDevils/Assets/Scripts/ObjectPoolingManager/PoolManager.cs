using System;
using UnityEngine;

namespace Assets.Scripts.ObjectPoolingManager
{
    public class PoolManager
    {
        private PoolPart[] _poolParts;
        private GameObject _parentObject;

        private static PoolManager _instance;

        public static PoolManager GetInstance()
        {
            return _instance ?? (_instance = new PoolManager());
        }

        public void Initialize(PoolPart[] poolParts)
        {
            _poolParts = poolParts;

            _parentObject = new GameObject {name = "Pool"};

            for (var i = 0; i < _poolParts.Length; i++)
            {
                if (_poolParts[i].Prefab != null)
                {
                    _poolParts[i].ObjectPooling = new ObjectPooling();
                    _poolParts[i].ObjectPooling.Initialize(_poolParts[i].Count, _poolParts[i].Prefab, _parentObject);
                }
            }
        }

        public GameObject PlacePooledObject(string name, Vector3 position, Quaternion rotation)
        {
            if (_poolParts == null) return null;

            for (var i = 0; i < _poolParts.Length; i++)
            {
                if (string.Equals(_poolParts[i].Name, name, StringComparison.OrdinalIgnoreCase) == false) continue;

                var result = _poolParts[i].ObjectPooling.GetFromPool().gameObject;
                result.transform.position = position;
                result.transform.rotation = rotation;
                result.SetActive(true);

                return result;
            }
            return null;
        }
    }
}