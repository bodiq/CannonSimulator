using ScriptableObjects;
using UnityEngine;

namespace Trajectory
{
    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryHandler : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private CannonFireSettings cannonFireSettings;
        [SerializeField] private Transform firePoint;
    
        private TrajectoryCalculator _trajectoryCalculator;
        
        private Vector3 _startPosition;
        private Vector3 _startVelocity;

        private void Start()
        {
            _trajectoryCalculator = new TrajectoryCalculator(cannonFireSettings);
        }

        private void LateUpdate()
        {
            DrawTrajectory();
        }

        private void DrawTrajectory()
        {
            _startPosition = firePoint.position;
            _startVelocity = firePoint.forward * cannonFireSettings.StartSpeed;
            
            var points = _trajectoryCalculator.GetTrajectoryPoints(_startPosition, _startVelocity);
            
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
    }
}
