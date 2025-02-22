﻿using ScriptableObjects;
using UnityEngine;

namespace Cannon
{
    public class CannonMovement
    {
        private readonly Transform _mainConstruction;
        private readonly Transform _firePipe;
        private readonly CannonMovementSettings _cannonMovementSettings;

        private float _maxVerticalRotation;
        private float _minVerticalRotation;

        public CannonMovement(Transform mainConstruction, Transform firePipe, CannonMovementSettings cannonMovementSettings)
        {
            _mainConstruction = mainConstruction;
            _firePipe = firePipe;
            _cannonMovementSettings = cannonMovementSettings;
            
            SetRotationRange();
        }

        private void SetRotationRange()
        {
            _maxVerticalRotation = _firePipe.rotation.eulerAngles.z + _cannonMovementSettings.FirePipeMaxAngles;
            _minVerticalRotation = _firePipe.rotation.eulerAngles.z - _cannonMovementSettings.FirePipeMinAngles;
        }

        public void MoveCannon()
        {
            MoveHorizontal();
            MoveVertical();
        }

        private void MoveVertical()
        {
            var verticalInput = Input.GetAxis("Vertical");
            if (Mathf.Abs(verticalInput) > 0.1f)
            {
                var rotationAmount = verticalInput * Time.deltaTime * _cannonMovementSettings.VerticalRotationSpeed;
                
                var currentZRotation = _firePipe.eulerAngles.z;
                currentZRotation = Mathf.Clamp(currentZRotation - rotationAmount, _minVerticalRotation, _maxVerticalRotation);
                
                
                _firePipe.eulerAngles = new Vector3(_firePipe.eulerAngles.x, _firePipe.eulerAngles.y, currentZRotation);
            }
        }

        private void MoveHorizontal()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(horizontalInput) > 0.1f)
            {
                var rotationAmount = horizontalInput * Time.deltaTime * _cannonMovementSettings.HorizontalRotationSpeed;
                _mainConstruction.Rotate(Vector3.up, rotationAmount);
            }
        }
    }
}