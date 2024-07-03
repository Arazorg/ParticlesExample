using System;
using UnityEngine;

namespace CodeBase.Data.Particles.Data
{
    [Serializable]
    public class SpawnableParticleData
    {
        public GameObject ParticlePrefab;
        public Vector3 SpawnOffset;
        public Quaternion Quaternion;
        public bool IsDestroyable;
    }
}