using UnityEngine;

namespace Projectile
{
    public class ProjectileImpact : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 4f;
        
        public void SetSelfDestruct()
        {
            CancelInvoke(nameof(DisableImpact)); 
            Invoke(nameof(DisableImpact), lifeTime);
        }
        
        private void DisableImpact()
        {
            if (gameObject.activeSelf) 
            {
                gameObject.SetActive(false);
            }
        }
    }
}