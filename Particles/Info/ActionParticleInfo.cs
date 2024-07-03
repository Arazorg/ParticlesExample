using CodeBase.Data.Block;
using CodeBase.Types;
using UnityEngine;

namespace CodeBase.Data.Particles.Info
{
    public class ActionParticleInfo : SpawnedParticleInfoData
    {
        public ParticleActionType ParticleActionType { get; }
        
        public ActionParticleInfo(ParticleActionType particleActionType, Vector3 position) : base(position)
        {
            ParticleActionType = particleActionType;
        }
    }
}