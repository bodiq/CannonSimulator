using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CannonMovementSettings", menuName = "ScriptableObjects/CannonMovementSettings")]
    public class CannonMovementSettings : ScriptableObject
    {
        [SerializeField] private float firePipeMaxAnglesOffset = 45f;
        [SerializeField] private float firePipeMinAnglesOffset = 10f;
        [SerializeField] private float verticalRotationSpeed = 100f;
        [SerializeField] private float horizontalRotationSpeed = 100f;
        [SerializeField] private float cameraSpotRotationSpeed = 10f;
        
        public float FirePipeMaxAngles => firePipeMaxAnglesOffset;
        public float FirePipeMinAngles => firePipeMinAnglesOffset;
        public float VerticalRotationSpeed => verticalRotationSpeed;
        public float HorizontalRotationSpeed => horizontalRotationSpeed;
        public float CameraSpotRotationSpeed => cameraSpotRotationSpeed;
    }
}