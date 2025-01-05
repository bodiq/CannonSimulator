using System.Collections.Generic;
using Cannon;
using UnityEngine;

namespace Poolers
{
    public class ProjectilePooler : MonoBehaviour
    {
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private int poolSize;
        [SerializeField] private Transform parent;
        
        private readonly Queue<Projectile> _projectiles = new();

        private void Awake()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var projectile = Instantiate(projectilePrefab, parent);
                projectile.gameObject.SetActive(false);
                _projectiles.Enqueue(projectile);
            }
        }

        public Projectile GetProjectile()
        {
            if (_projectiles == null || _projectiles.Count == 0)
            {
                return null;
            }
            
            return _projectiles.Dequeue();
        }

        public void ReturnProjectile(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            _projectiles.Enqueue(projectile);
        }
    }
}