using System.Collections.Generic;
using System.Linq;
using CodeBase.Data.Particles;

namespace CodeBase.Infrastructure.Factory.Game.Particles
{
    public class BlockParticlesFactory : BaseParticleFactory<BlockParticleInfo>
    {
        private readonly AllBlocksSpawnableParticles _allParticles;

        public BlockParticlesFactory(AllBlocksSpawnableParticles allParticles)
        {
            _allParticles = allParticles;
        }

        public override void HandleParticleInfo(BlockParticleInfo particleInfo)
        {
            List<BlockSpawnableParticlesData> allParticlesData = _allParticles.SpawnableParticlesData;
            BlockSpawnableParticlesData particleData = allParticlesData.FirstOrDefault
                (particle => particle.BlockType == particleInfo.BlockType);

            if (particleData == null) 
                return;
            
            CreateParticle(particleData, particleInfo);
        }
    }
}