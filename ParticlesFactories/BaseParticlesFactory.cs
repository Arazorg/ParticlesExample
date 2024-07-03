using CodeBase.Data.Block;
using CodeBase.Data.Particles;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory.Game.Particles
{
    public abstract class BaseParticlesFactory<T> : IParticlesFactory<T>
    {
        public abstract void HandleParticleInfo(T particleInfo);

        protected void CreateParticle(SpawnableParticlesData particles, SpawnedParticleInfo particleInfo)
        {
            foreach (SpawnableParticleData data in particles.ParticlesData)
            {
                Vector3 spawnPosition = particleInfo.Position + data.SpawnOffset;
                if (data.IsDestroyable)
                {
                    InstantiateAndDestroyParticle(data.ParticlePrefab, 
                        spawnPosition, data.Quaternion);
                }
                else
                {
                    InstantiateParticle(data.ParticlePrefab, 
                        spawnPosition, data.Quaternion);
                }
            }
        }

        private void InstantiateParticle(GameObject prefab, Vector3 spawnPosition, Quaternion rotation)
        {
            Object.Instantiate(prefab, spawnPosition, rotation);
        }

        private void InstantiateAndDestroyParticle(GameObject prefab, Vector3 spawnPosition, Quaternion rotation)
        {
            if (prefab.TryGetComponent(out ParticleSystem _))
            {
                ParticleSystem particle = Object.Instantiate(prefab, spawnPosition, rotation)
                    .GetComponent<ParticleSystem>();
                
                Object.Destroy(particle.gameObject, particle.main.duration);
            }
        }
    }
}