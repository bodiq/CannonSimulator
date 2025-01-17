using Poolers;
using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class CannonController : MonoBehaviour
    {
        [Header("Cannon Objects")]
        [SerializeField] private Transform cameraSpot;
        [SerializeField] private Transform mainConstruction;
        [SerializeField] private Transform cannonPipe;
        [SerializeField] private Transform firePoint;

        [Header("Scriptable Objects")]
        [SerializeField] private CannonMovementSettings cannonMovementSettings;
        [SerializeField] private CannonFireSettings cannonFireSettings;
        
        [Header("Poolers")]
        [SerializeField] private ProjectilePooler projectilePooler;
        [SerializeField] private ParticleExplodePooler particleExplodePooler;
        [SerializeField] private ImpactPooler impactPooler;

        private CannonCamera _cannonCamera;
        private CannonMovement _cannonMovement;
        private CannonFire _cannonFire;

        private float _nextFireTime = 0;
        
        private void Start()
        {
            _cannonCamera = new CannonCamera(cameraSpot, mainConstruction, cannonMovementSettings);
            _cannonMovement = new CannonMovement(mainConstruction, cannonPipe, cannonMovementSettings);
            _cannonFire = new CannonFire(projectilePooler, cannonFireSettings, firePoint, cannonPipe, particleExplodePooler, impactPooler);
        }

        private void Update()
        {
            _cannonMovement.MoveCannon();

            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + cannonFireSettings.FireRate;
                _cannonFire.Shoot();
                _cannonCamera.StartShake(0.1f, 0.05f);
            }
            
            _cannonFire.TryPlayRecoilAnimation();
        }

        private void LateUpdate()
        {
            _cannonCamera.SetCannonCamera(); 
        }
    }
}
