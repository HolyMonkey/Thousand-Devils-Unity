using Assets.Scripts.ObjectPoolingManager;
using UnityEngine;

namespace Assets.Scripts.Cannonball
{
    public class Cannonball : PoolObject
    {
        [SerializeField] private uint _damage;
        
        public uint Damage => _damage;

        void Start()
        {
            _damage = 100;
        }
    }
}
