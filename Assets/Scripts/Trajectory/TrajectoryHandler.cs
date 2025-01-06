using System;
using GlobalHandlers;
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

        private float _power;

        private void OnEnable()
        {
            EventsHandler.OnPowerChange += OnPowerChange;
        }

        private void Start()
        {
            _trajectoryCalculator = new TrajectoryCalculator(cannonFireSettings);
        }

        private void LateUpdate()
        {
            DrawTrajectory();
        }

        private void OnPowerChange(float value)
        {
            _power = value;
        }

        private void DrawTrajectory()
        {
            _startPosition = firePoint.position;
            _startVelocity = firePoint.forward * _power;
            
            var points = _trajectoryCalculator.GetTrajectoryPoints(_startPosition, _startVelocity);
            
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }

        private void OnDisable()
        {
            EventsHandler.OnPowerChange -= OnPowerChange;
        }
    }
}
