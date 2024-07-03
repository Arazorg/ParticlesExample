using System.Collections.Generic;
using CodeBase.Data.Particles.Data;
using UnityEngine;

namespace CodeBase.Data.Particles.SO
{
    [CreateAssetMenu]
    public class AllActionSpawnableParticles : ScriptableObject
    {
        [SerializeField] private List<ActionSpawnableParticlesData> _spawnableParticlesData;

        public List<ActionSpawnableParticlesData> SpawnableParticlesData => new(_spawnableParticlesData);
    }
}