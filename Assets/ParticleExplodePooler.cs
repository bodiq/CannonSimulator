using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticleExplodePooler : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private int poolSize;
    [SerializeField] private Transform parent;
        
    private readonly List<ParticleSystem> _particles = new();

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (var i = 0; i < poolSize; i++)
        {
            var projectile = Instantiate(particle, parent);
            projectile.gameObject.SetActive(false);
            _particles.Add(projectile);
        }
    }

    public void PlayExplosion(Vector3 position)
    {
        if (_particles == null || _particles.Count == 0)
        {
            return;
        }

        var firstActiveParticle = _particles.FirstOrDefault(particle => !particle.gameObject.activeSelf);
        if (firstActiveParticle != null)
        {
            firstActiveParticle.transform.position = position;
            firstActiveParticle.gameObject.SetActive(true);
            firstActiveParticle.Play();
        }
    }
}
