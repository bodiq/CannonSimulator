using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CannonFireSettings", menuName = "ScriptableObjects/CannonFireSettings")]
    public class CannonFireSettings : ScriptableObject
    {
        [SerializeField] private float gravity;
        [SerializeField] private int resolutionPoints;
        [SerializeField] private int maxBounces;
        [SerializeField] private float minPower;
        [SerializeField] private float maxPower;
        [SerializeField] private float timeStep;
        [SerializeField] private float bounceDamping;
        [SerializeField] private float recoilSpeed;
        
        public float Gravity => gravity;
        public int ResolutionPoints => resolutionPoints;
        public int MaxBounces => maxBounces;
        public float MinPower => minPower;
        public float MaxPower => maxPower;
        public float TimeStep => timeStep;
        public float BounceDamping => bounceDamping;
        public float RecoilSpeed => recoilSpeed;
    }
}