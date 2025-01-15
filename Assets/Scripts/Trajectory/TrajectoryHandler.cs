using System;
using GlobalHandlers;
using ScriptableObjects;
using UnityEngine;

namespace Trajectory
{
    public delegate void MyDelegate();
    
    [RequireComponent(typeof(LineRenderer))]
    public class TrajectoryHandler : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private CannonFireSettings cannonFireSettings;
        [SerializeField] private Transform firePoint;
        
        [SerializeField] private Color lineColor = Color.white; 
        [SerializeField] private float lineWidth = 0.1f;
    
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
            SetupLineRenderer();
        }

        private void LateUpdate()
        {
            DrawTrajectory();
        }

        private void SetupLineRenderer()
        {
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
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
            
            if (points == null || points.Count == 0)
            {
                Debug.LogWarning("Trajectory points are empty!");
                lineRenderer.positionCount = 0;
                return;
            }
            
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }

        private void OnDisable()
        {
            EventsHandler.OnPowerChange -= OnPowerChange;
        }
    }
}
