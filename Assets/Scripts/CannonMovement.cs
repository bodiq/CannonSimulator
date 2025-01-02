using UnityEngine;

namespace DefaultNamespace
{
    public class CannonMovement
    {
        private Transform _mainConstruction;
        private Transform _firePipe;


        public CannonMovement(Transform mainConstruction, Transform firePipe)
        {
            _mainConstruction = mainConstruction;
            _firePipe = firePipe;
        }

        public void MoveCannon()
        {
            MoveHorizontal();
            MoveVertical();
        }

        private void MoveVertical()
        {
            var rotation = Input.GetAxis("Vertical") * Time.deltaTime * 100f;
            _firePipe.rotation = Quaternion.Euler( _firePipe.rotation.x,  _firePipe.rotation.y,  _firePipe.rotation.z + rotation);
        }

        private void MoveHorizontal()
        {
            var movement = Input.GetAxis("Horizontal") * Time.deltaTime * 100f;
            _mainConstruction.rotation = Quaternion.Euler(_mainConstruction.rotation.x, _mainConstruction.rotation.y + movement, _mainConstruction.rotation.z);
        }
    }
}