using CodeBase.Data.Block;
using CodeBase.Types.BlocksTypes;
using UnityEngine;

namespace CodeBase.Data.Particles.Info
{
    public class BlockParticleInfo : SpawnedParticleInfoData
    {
        public BlockType BlockType { get; set; }

        protected BlockParticleInfo(BlockType blockType, Vector3 position) : base(position)
        {
            BlockType = blockType;
        }
    }
}