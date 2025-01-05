using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CannonFireSettings", menuName = "ScriptableObjects/CannonFireSettings")]
    public class CannonFireSettings : ScriptableObject
    {
        [SerializeField] private float gravity;
        [SerializeField] private int resolutionPoints;
        [SerializeField] private int maxBounces;
        [SerializeField] private float startSpeed;
        [SerializeField] private float timeStep;
        [SerializeField] private float bounceDamping;
        
        public float Gravity => gravity;
        public int ResolutionPoints => resolutionPoints;
        public int MaxBounces => maxBounces;
        public float StartSpeed => startSpeed;
        public float TimeStep => timeStep;
        public float BounceDamping => bounceDamping;
    }
}