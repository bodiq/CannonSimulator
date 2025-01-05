using Poolers;
using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class CannonFire
    {
        private readonly Transform _firePoint;
        private readonly ProjectilePooler _projectilePooler;
        private readonly CannonFireSettings _cannonFireSettings;

        public CannonFire(ProjectilePooler projectilePooler, Transform firePoint)
        {
            _firePoint = firePoint;
            _projectilePooler = projectilePooler;
        }
        
        public void Shoot()
        {
            var projectile = _projectilePooler.GetProjectile();
            projectile.Initialize(_firePoint, _projectilePooler);
            projectile.gameObject.SetActive(true);
        }
    }
}