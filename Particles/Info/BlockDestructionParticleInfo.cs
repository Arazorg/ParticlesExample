using CodeBase.Types.BlocksTypes;
using UnityEngine;

namespace CodeBase.Data.Particles.Info
{
    public class BlockDestructionParticleInfo : BlockParticleInfo
    {
        public Material Material { get; }
        public int NumberTextureInArray { get; }

        public BlockDestructionParticleInfo(BlockType blockType, Material material, 
            int numberTextureInArray, Vector3 position) : base(blockType, position)
        {
            Material = material;
            NumberTextureInArray = numberTextureInArray;
        }
    }
}