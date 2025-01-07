using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CannonFireSettings", menuName = "ScriptableObjects/CannonFireSettings")]
    public class CannonFireSettings : ScriptableObject
    {
        [Tooltip("Гравітація, яка діє на снаряд")]
        [SerializeField] private float gravity = 9.8f;

        [Tooltip("Кількість точок для розрахунку траєкторії")]
        [SerializeField] private int resolutionPoints = 30;

        [Tooltip("Максимальна кількість відскоків")]
        [SerializeField] private int maxBounces = 3;

        [Tooltip("Мінімальна потужність пострілу")]
        [SerializeField] private float minPower = 10f;

        [Tooltip("Максимальна потужність пострілу")]
        [SerializeField] private float maxPower = 100f;

        [Tooltip("Часовий крок для фізичних розрахунків")]
        [SerializeField] private float timeStep = 0.02f;

        [Tooltip("Коефіцієнт загасання швидкості після відскоку")]
        [SerializeField] private float bounceDamping = 0.8f;

        [Tooltip("Швидкість відкату гармати")]
        [SerializeField] private float recoilSpeed = 5f;

        [Tooltip("Зміщення сліду від поверхні, щоб не було накладень")]
        [SerializeField] private float impactOffset = 0.01f;
        
        [Tooltip("Затримка перед стрільбою")]
        [SerializeField] private float fireRate = 0.5f;
        
        
        public float Gravity => gravity;
        public int ResolutionPoints => resolutionPoints;
        public int MaxBounces => maxBounces;
        public float MinPower => minPower;
        public float MaxPower => maxPower;
        public float TimeStep => timeStep;
        public float BounceDamping => bounceDamping;
        public float RecoilSpeed => recoilSpeed;
        public float ImpactOffset => impactOffset;
        public float FireRate => fireRate;
    }
}