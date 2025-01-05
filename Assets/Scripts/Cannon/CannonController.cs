using Poolers;
using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class CannonController : MonoBehaviour
    {
        [SerializeField] private Transform cameraSpot;
        [SerializeField] private Transform mainConstruction;
        [SerializeField] private Transform cannonPipe;
        [SerializeField] private Transform firePoint;

        [SerializeField] private CannonMovementSettings cannonMovementSettings;
        [SerializeField] private ProjectilePooler projectilePooler;

        private CannonCamera _cannonCamera;
        private CannonMovement _cannonMovement;
        private CannonFire _cannonFire;

        private void Start()
        {
            _cannonCamera = new CannonCamera(Camera.main, cameraSpot, mainConstruction, cannonMovementSettings);
            _cannonMovement = new CannonMovement(mainConstruction, cannonPipe, cannonMovementSettings);
            _cannonFire = new CannonFire(projectilePooler, firePoint);
        }

        private void Update()
        {
            _cannonMovement.MoveCannon();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _cannonFire.Shoot();
            }
        }

        private void LateUpdate()
        {
            _cannonCamera.SetCannonCamera(); 
        }
    }
}
