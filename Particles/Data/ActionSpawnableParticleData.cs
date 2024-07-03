using System;
using CodeBase.Types;

namespace CodeBase.Data.Particles.Data
{
    [Serializable]
    public class ActionSpawnableParticlesData : SpawnableParticlesData
    {
        public ParticleActionType ParticleActionType;
    }
}