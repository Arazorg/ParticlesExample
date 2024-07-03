using System.Collections.Generic;
using CodeBase.Data.Particles.Data;
using UnityEngine;

namespace CodeBase.Data.Particles.SO
{
    [CreateAssetMenu]
    public class AllBlocksSpawnableParticles : ScriptableObject
    {
        [SerializeField] private List<BlockSpawnableParticlesData> _spawnableParticlesData;
        
        public List<BlockSpawnableParticlesData> SpawnableParticlesData => new(_spawnableParticlesData);
    }
}