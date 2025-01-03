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

        private CannonCameraSpot _cannonCameraSpot;
        private CannonMovement _cannonMovement;

        private void Start()
        {
            _cannonCameraSpot = new CannonCameraSpot(Camera.main, cameraSpot, mainConstruction, cannonMovementSettings);
            _cannonMovement = new CannonMovement(mainConstruction, cannonPipe, cannonMovementSettings);
        }

        private void Update()
        {
            _cannonCameraSpot.SetCannonCamera();
            _cannonMovement.MoveCannon();
        }
    }
}
