using System;

namespace Assets.Scripts.ObjectPoolingManager
{
    [Serializable]
    public struct PoolPart
    {
        public string Name;
        public PoolObject Prefab;
        public int Count;
        public ObjectPooling ObjectPooling;
    }
}