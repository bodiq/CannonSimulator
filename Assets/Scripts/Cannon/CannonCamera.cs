using System.Collections;
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
        
        private bool _isShaking; 
        private Vector3 _originalCamPosition; 
        private float _shakeDuration; 
        private float _shakeMagnitude;

        public CannonCamera(Transform cameraSpot, Transform cannonConstruction, CannonMovementSettings cannonMovementSettings)
        {
            _cam = Camera.main;
            _camSpot = cameraSpot;
            _cannonConstruction = cannonConstruction;
            _cannonMovementSettings = cannonMovementSettings;
        }

        public void SetCannonCamera()
        {
            if (_cam != null) _cam.transform.position = _camSpot.position;
        
            var targetRotation = new Vector3(0f, _cannonConstruction.eulerAngles.y + _cameraYOffset, 0f);
        
            _cam.transform.rotation = Quaternion.Lerp(_cam.transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * _cannonMovementSettings.CameraSpotRotationSpeed);

            if (_isShaking)
            {
                ShakeCamera(); 
            }
        }

        public void StartShake(float duration, float magnitude)
        {
            _originalCamPosition = _cam.transform.localPosition; 
            _shakeDuration = duration; 
            _shakeMagnitude = magnitude; 
            _isShaking = true;
        }
        
        private void ShakeCamera() 
        {
            if (_shakeDuration > 0)
            {
                var offsetX = Random.Range(-1f, 1f) * _shakeMagnitude; 
                var offsetY = Random.Range(-1f, 1f) * _shakeMagnitude; 
                _cam.transform.localPosition = _originalCamPosition + new Vector3(offsetX, offsetY, 0f); 
                _shakeDuration -= Time.deltaTime;
            }
            else
            {
                _isShaking = false; 
                _cam.transform.localPosition = _originalCamPosition; 
            } 
        }
    }
}
