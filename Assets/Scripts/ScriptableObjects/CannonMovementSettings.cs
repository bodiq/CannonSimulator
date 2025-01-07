using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CannonMovementSettings", menuName = "ScriptableObjects/CannonMovementSettings")]
    public class CannonMovementSettings : ScriptableObject
    {
        [Tooltip("Максимальний кут підйому гармати")]
        [SerializeField] private float firePipeMaxAnglesOffset = 45f;

        [Tooltip("Мінімальний кут підйому гармати")]
        [SerializeField] private float firePipeMinAnglesOffset = 10f;

        [Tooltip("Швидкість вертикального обертання гармати")]
        [SerializeField] private float verticalRotationSpeed = 100f;

        [Tooltip("Швидкість горизонтального обертання гармати")]
        [SerializeField] private float horizontalRotationSpeed = 100f;

        [Tooltip("Швидкість обертання точки камери")]
        [SerializeField] private float cameraSpotRotationSpeed = 10f;
        
        public float FirePipeMaxAngles => firePipeMaxAnglesOffset;
        public float FirePipeMinAngles => firePipeMinAnglesOffset;
        public float VerticalRotationSpeed => verticalRotationSpeed;
        public float HorizontalRotationSpeed => horizontalRotationSpeed;
        public float CameraSpotRotationSpeed => cameraSpotRotationSpeed;
    }
}