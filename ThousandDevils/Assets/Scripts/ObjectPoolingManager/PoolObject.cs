using UnityEngine;

namespace Assets.Scripts.ObjectPoolingManager
{
    public class PoolObject : MonoBehaviour
    {
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}