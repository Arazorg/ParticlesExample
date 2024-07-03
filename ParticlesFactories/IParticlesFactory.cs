namespace CodeBase.Infrastructure.Factory.Game.Particles
{
    public interface IParticlesFactory<T>
    {
        void HandleParticleInfo(T particleInfo);
    }
}