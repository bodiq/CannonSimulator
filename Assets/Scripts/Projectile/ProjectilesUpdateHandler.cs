using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Projectile
{
    public class ProjectilesUpdateHandler : MonoBehaviour
    {
        private readonly List<Projectile> _projectiles = new();

        private void FixedUpdate()
        {
            foreach (var projectile in _projectiles.Where(projectile => projectile.isActiveAndEnabled))
            {
                projectile.SimulateProjectile();
            }
        }

        public void AddProjectile(Projectile projectile)
        {
            _projectiles.Add(projectile);
        }

        public void RemoveProjectile(Projectile projectile)
        {
            _projectiles.Remove(projectile);
        }
    }
}
