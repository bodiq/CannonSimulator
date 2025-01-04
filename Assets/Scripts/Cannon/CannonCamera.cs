using ScriptableObjects;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Cannon
{
    public class CannonCamera
    {
        private readonly Camera _cam;
        private readonly Transform _camSpot;
        private readonly Transform _cannonConstruction;

        private readonly float _cameraYOffset = 90f;
        
        private readonly CannonMovementSettings _cannonMovementSettings;

        public CannonCamera(Camera cam, Transform cameraSpot, Transform cannonConstruction, CannonMovementSettings cannonMovementSettings)
        {
            _cam = cam;
            _camSpot = cameraSpot;
            _cannonConstruction = cannonConstruction;
            _cannonMovementSettings = cannonMovementSettings;
        }

        public void SetCannonCamera()
        {
            if (_cam != null) _cam.transform.position = _camSpot.position;
        
            var targetRotation = new Vector3(0f, _cannonConstruction.eulerAngles.y + _cameraYOffset, 0f);
        
            _cam.transform.rotation = Quaternion.Lerp(_cam.transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * _cannonMovementSettings.CameraSpotRotationSpeed);
        }
    }
}
