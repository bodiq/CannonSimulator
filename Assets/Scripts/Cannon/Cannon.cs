using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Transform cameraSpot;
        [SerializeField] private Transform mainConstruction;
        [SerializeField] private Transform cannonPipe;

        [SerializeField] private CannonMovementSettings cannonMovementSettings;

        private CannonCamera _cannonCamera;
        private CannonMovement _cannonMovement;

        private void Start()
        {
            _cannonCamera = new CannonCamera(Camera.main, cameraSpot, mainConstruction, cannonMovementSettings);
            _cannonMovement = new CannonMovement(mainConstruction, cannonPipe, cannonMovementSettings);
        }

        private void Update()
        {
            _cannonMovement.MoveCannon();
        }

        private void LateUpdate()
        {
            _cannonCamera.SetCannonCamera(); 
        }
    }
}
