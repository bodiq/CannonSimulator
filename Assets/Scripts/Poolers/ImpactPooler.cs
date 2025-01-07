using System.Collections.Generic;
using System.Linq;
using Projectile;
using UnityEngine;

namespace Poolers
{
    public class ImpactPooler : MonoBehaviour
    {
        [SerializeField] private ProjectileImpact impact;
        [SerializeField] private int poolSize;
        
        private readonly List<ProjectileImpact> _impacts = new();
        
        private Transform _impactsParent;

        private void Awake()
        {
            CreateParent();
            InitializePool();
        }
        
        private void CreateParent()
        {
            var parentObject = new GameObject("ImpactParentPooler");
            _impactsParent = parentObject.transform;
        }

        private void InitializePool()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var projectileImpact = Instantiate(impact, _impactsParent);
                projectileImpact.gameObject.SetActive(false);
                _impacts.Add(projectileImpact);
            }
        }

        public ProjectileImpact GetImpact()
        {
            if (_impacts == null || _impacts.Count == 0)
            {
                return null;
            }

            var firstActiveImpact = _impacts.FirstOrDefault(system => !system.gameObject.activeSelf);
            if (firstActiveImpact != null)
            {
                firstActiveImpact.SetSelfDestruct();
                return firstActiveImpact;
            }

            return null;
        }
    }
}
