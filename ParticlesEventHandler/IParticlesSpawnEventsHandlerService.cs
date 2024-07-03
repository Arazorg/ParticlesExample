using CodeBase.Infrastructure.Factory.Game.Particles;
using IService = CodeBase.Infrastructure.Services.IService;

namespace CodeBase.Logic.Particles
{
    public interface IParticlesSpawnEventsHandlerService : IService
    {
        void RegisterFactory<T>(IParticlesFactory<T> factory);
        void RegisterEmitter<T>(IParticleSpawnEmitter<T> emitter);
        void UnregisterEmitter<T>(IParticleSpawnEmitter<T> emitter);
    }
}