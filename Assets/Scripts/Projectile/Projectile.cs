using Poolers;
using ScriptableObjects;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private CannonFireSettings cannonFireSettings;
        [SerializeField] private ProjectileMeshGenerator projectileMeshGenerator;
        
        private static ProjectilePooler _pooler;
        
        private int _bounces;
        
        private Vector3 _velocity;
        private Vector3 _position;

        public void OnCreate()
        {
            transform.position = Vector3.zero;
            projectileMeshGenerator.SetRandomMesh();
        }
        
        public void Initialize(Transform startPos, ProjectilePooler projectilePooler, float powerShoot)
        {
            _position = startPos.position;
            _velocity = startPos.forward * powerShoot;
            _pooler = projectilePooler;
            
            transform.position = _position;
        }

        private void SimulateProjectile()
        {
            if (_bounces > cannonFireSettings.MaxBounces)
            {
                _bounces = 0;
                _pooler.ReturnProjectile(this);
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
            }
        }

        private void FixedUpdate()
        {
            SimulateProjectile();
        }
    }
}