using Poolers;
using ScriptableObjects;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private CannonFireSettings cannonFireSettings;
        [SerializeField] private ProjectileMeshGenerator projectileMeshGenerator;
        
        private static ProjectilePooler _projectilePooler;
        private static ParticleExplodePooler _explodePooler;
        private static ImpactPooler _impactPooler;
        
        private int _bounces;
        
        private Vector3 _velocity;
        private Vector3 _position;

        public void OnCreate()
        {
            transform.position = Vector3.zero;
            projectileMeshGenerator.SetRandomMesh();
        }
        
        public void Initialize(Transform startPos, ProjectilePooler projectilePooler, float powerShoot, ParticleExplodePooler explodePooler, ImpactPooler impactPooler)
        {
            _position = startPos.position;
            _velocity = startPos.forward * powerShoot;
            _projectilePooler = projectilePooler;
            _explodePooler = explodePooler;
            _impactPooler = impactPooler;
            
            transform.position = _position;
        }

        public void SimulateProjectile()
        {
            if (_bounces > cannonFireSettings.MaxBounces)
            {
                _bounces = 0;
                _explodePooler.PlayExplosion(transform.position);
                _projectilePooler.ReturnProjectile(this);
                return;
            }
            
            _position += _velocity * Time.fixedDeltaTime;
            _velocity.y += cannonFireSettings.Gravity * Time.fixedDeltaTime;
            transform.position = _position;

            if (Physics.Raycast(_position, _velocity, out RaycastHit hit, _velocity.magnitude * Time.fixedDeltaTime))
            {
                _bounces++;
                _velocity = Vector3.Reflect(_velocity, hit.normal) * cannonFireSettings.BounceDamping;
                transform.position = hit.point;

                if (hit.collider.CompareTag("Wall"))
                {
                    CreateImpact(hit.point, hit.normal);
                }
            }
        }
        
        private void CreateImpact(Vector3 position, Vector3 normal)
        {
            var impact = _impactPooler.GetImpact();
            
            if (impact == null)
            {
                Debug.LogWarning("Impact pool is empty!");
                return;
            }
            
            impact.gameObject.SetActive(true);
            impact.transform.position = position + normal * cannonFireSettings.ImpactOffset;
            impact.transform.rotation = Quaternion.LookRotation(normal);
            impact.SetSelfDestruct();
        }
    }
}