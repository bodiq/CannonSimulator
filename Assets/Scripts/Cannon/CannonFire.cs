using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class CannonFire : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private CannonFireSettings cannonFireSettings;
        
        public void Shoot()
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            StartCoroutine(ProjectileShoot(projectile));
        }

        private IEnumerator ProjectileShoot(GameObject projectile)
        {
            var velocity = firePoint.forward * cannonFireSettings.StartSpeed;
            var position = projectile.transform.position;

            var bounces = 0;
            
            while (true)
            {
                if (bounces > cannonFireSettings.MaxBounces) break;
                
                position += velocity * Time.deltaTime;
                velocity.y += cannonFireSettings.Gravity * Time.deltaTime;

                projectile.transform.position = position;

                if (Physics.Raycast(position, velocity, out RaycastHit hit, velocity.magnitude * Time.deltaTime))
                {
                    Debug.LogError("Hit: " + hit.collider.name);
                    bounces++;
                    velocity = Vector3.Reflect(velocity, hit.normal) * cannonFireSettings.BounceDamping;
                    position = hit.point;
                }
                
                yield return null;
            }
        }
    }
}