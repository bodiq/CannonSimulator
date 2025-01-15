using System.Collections.Generic;
using Cannon;
using Projectile;
using UnityEngine;

namespace Poolers
{
    public class ProjectilePooler : MonoBehaviour
    {
        [SerializeField] private Projectile.Projectile projectilePrefab;
        [SerializeField] private int poolSize;
        [SerializeField] private Transform parent;
        [SerializeField] private ProjectilesUpdateHandler projectilesUpdateHandler;
        
        private readonly Queue<Projectile.Projectile> _projectiles = new();

        private void Awake()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var projectile = Instantiate(projectilePrefab, parent);
                projectile.OnCreate();
                projectile.gameObject.SetActive(false);
                projectilesUpdateHandler.AddProjectile(projectile);
                _projectiles.Enqueue(projectile);
            }
        }

        public Projectile.Projectile GetProjectile()
        {
            if (_projectiles == null || _projectiles.Count == 0)
            {
                return null;
            }

            return _projectiles.Dequeue();
        }

        public void ReturnProjectile(Projectile.Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            _projectiles.Enqueue(projectile);
        }
    }
}