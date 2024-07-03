using CodeBase.Data.Particles;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Logic.Particles;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory.Game.Particles
{
    public class DestructionBlockParticlesFactory : IParticlesFactory<DestructionBlockParticleInfoData>
    {
        private readonly IAssetProvider _assetProvider;

        public DestructionBlockParticlesFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void HandleParticleInfo(DestructionBlockParticleInfoData particleInfo)
        {
            Vector3 spawnPosition = particleInfo.Position;
            BlockDestructionParticle particle = _assetProvider.InstantiateAt<BlockDestructionParticle>
                    (ParticlesAssetPath.BlockDestructionParticlePath, spawnPosition);
            
            particle.Init(particleInfo);
        }
    }
}