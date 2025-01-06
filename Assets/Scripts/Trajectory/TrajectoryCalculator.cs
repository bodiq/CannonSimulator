using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Trajectory
{
    public class TrajectoryCalculator
    {
        private readonly List<Vector3> _trajectoryPoints = new();

        private readonly CannonFireSettings _cannonFireSettings;
        
        private Vector3 _positionPoint;
        private Vector3 _velocity;
        
        public TrajectoryCalculator(CannonFireSettings fireSettings)
        {
            _cannonFireSettings = fireSettings;
        }

        public List<Vector3> GetTrajectoryPoints(Vector3 startPoint, Vector3 velocity)
        {
            _trajectoryPoints.Clear();
            _positionPoint = startPoint;
            _velocity = velocity;
            
            for (var i = 0; i < _cannonFireSettings.ResolutionPoints; i++)
            {
                _trajectoryPoints.Add(_positionPoint);

                _positionPoint += _velocity * _cannonFireSettings.TimeStep;
                _velocity.y += _cannonFireSettings.Gravity * _cannonFireSettings.TimeStep;

                if (Physics.Raycast(_positionPoint, _velocity, out RaycastHit hitInfo, _velocity.magnitude * _cannonFireSettings.TimeStep, 0))
                {
                    _positionPoint = hitInfo.point;
                    break;
                }
            }
            
            return _trajectoryPoints;
        }
    }
}