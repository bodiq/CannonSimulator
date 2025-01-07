using UnityEngine;

namespace Projectile
{
    public class ProjectileImpact : MonoBehaviour
    {
        private static float _lifeTime = 4f;
        
        public void SetSelfDestruct()
        {
            Invoke(nameof(DisableImpact), _lifeTime);
        }

        private void DisableImpact()
        {
            gameObject.SetActive(false);
        }
    }
}