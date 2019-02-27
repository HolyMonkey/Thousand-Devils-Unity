using UnityEngine;

namespace Assets.Scripts.ObjectPoolingManager
{
    public class PoolSetup : MonoBehaviour
    {
        [SerializeField] private PoolPart[] _poolParts;

        void OnValidate()
        {
            for (int i = 0; i < _poolParts.Length; i++)
            {
                _poolParts[i].Name = _poolParts[i].Prefab.name;
            }
        }

        void Awake()
        {
            Initialize();
        }

        void Initialize()
        {
            PoolManager.GetInstance().Initialize(_poolParts);
        }
    }
}