using System;
using CodeBase.Types.BlocksTypes;

namespace CodeBase.Data.Particles.Data
{
    [Serializable]
    public class BlockSpawnableParticlesData : SpawnableParticlesData
    {
        public BlockType BlockType;
    }
}