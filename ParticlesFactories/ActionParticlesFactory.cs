using System.Collections.Generic;
using System.Linq;
using CodeBase.Data.Block;
using CodeBase.Data.Particles;

namespace CodeBase.Infrastructure.Factory.Game.Particles
{
    public class ActionParticlesFactory : BaseParticleFactory<ActionParticleInfo>
    {
        private readonly AllActionSpawnableParticles _allParticles;

        public ActionParticlesFactory(AllActionSpawnableParticles allParticles)
        {
            _allParticles = allParticles;
        }

        public override void HandleParticleInfo(ActionParticleInfo particleInfo)
        {
            List<ActionSpawnableParticlesData> allParticlesData = _allParticles.SpawnableParticlesData;
            ActionSpawnableParticlesData particleData = allParticlesData.FirstOrDefault
                (particle => particle.ParticleActionType == particleInfo.ParticleActionType);
            
            if (particleData == null) 
                return;
            
            CreateParticle(particleData, particleInfo);
        }
    }
}