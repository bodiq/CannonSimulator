using UnityEngine;

namespace DefaultNamespace
{
    public class CannonMovement
    {
        private readonly Transform _mainConstruction;
        private readonly Transform _firePipe;

        private float _maxVerticalRotation;
        private float _minVerticalRotation;
        
        private const float FirePipeMaxAnglesOffset = 45f;
        private const float FirePipeMinAnglesOffset = 10f;


        public CannonMovement(Transform mainConstruction, Transform firePipe)
        {
            _mainConstruction = mainConstruction;
            _firePipe = firePipe;
            
            SetRotationRange();
        }

        private void SetRotationRange()
        {
            _maxVerticalRotation = _firePipe.rotation.eulerAngles.z + FirePipeMaxAnglesOffset;
            _minVerticalRotation = _firePipe.rotation.eulerAngles.z - FirePipeMinAnglesOffset;
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
                var rotationAmount = verticalInput * Time.deltaTime * 100f;
                
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
                var rotationAmount = horizontalInput * Time.deltaTime * 100f;
                _mainConstruction.Rotate(Vector3.up, rotationAmount);
            }
        }
    }
}