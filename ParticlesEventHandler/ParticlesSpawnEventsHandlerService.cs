using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory.Game.Particles;

namespace CodeBase.Logic.Particles
{
    public class ParticlesSpawnEventsHandlerService : IParticlesSpawnEventsHandlerService
    {
        private readonly Dictionary<Type, object> _factories = new Dictionary<Type, object>();

        public void RegisterFactory<T>(IParticlesFactory<T> factory)
        {
            _factories[typeof(T)] = factory;
        }

        public void RegisterEmitter<T>(IParticleSpawnEmitter<T> emitter)
        {
            emitter.OnParticleSpawned += ParticleSpawned;
        }

        public void UnregisterEmitter<T>(IParticleSpawnEmitter<T> emitter)
        {
            emitter.OnParticleSpawned -= ParticleSpawned;
        }

        private void ParticleSpawned<T>(T type)
        {
            if (_factories.TryGetValue(typeof(T), out object factory))
                ((IParticlesFactory<T>)factory).HandleParticleInfo(type);
        }
    }
}