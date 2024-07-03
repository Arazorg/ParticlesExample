using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Data.Block;
using CodeBase.Logic.Particles;
using CodeBase.Types;
using UnityEngine;

namespace CodeBase.Logic.Bonuses.Blocks
{
    [RequireComponent(typeof(MeshFilter))]
    public abstract class SpawnableBonus : MonoBehaviour, IParticleSpawnEmitter<ActionParticleInfo>
    {
        [SerializeField] private float _movingDuration;
        
        private Coroutine _liveTimerCoroutine;
        private MeshFilter _meshFilter;

        public Transform Transform => transform;
        
        public float MeshHeight
        {
            get
            {
                if (_meshFilter != null)
                    return _meshFilter.mesh.bounds.size.y / 2;

                return 0;
            }
        }
        
        public float MovingDuration => _movingDuration;
        
        public event Action<ActionParticleInfo> OnParticleSpawned;

        protected void StartLiveCoroutine(float liveDuration)
        {
            _liveTimerCoroutine = StartCoroutine(LiveTimer(liveDuration));
        }

        protected void SetUV(int textureNumber, int currentCurrencyNumber)
        {
            _meshFilter = GetComponent<MeshFilter>();

            Mesh mesh = _meshFilter.mesh;
            List<Vector2> uvs = new List<Vector2>();

            for (int i = 0; i < mesh.uv.Length; i++)
                uvs.Add(new Vector2(textureNumber, currentCurrencyNumber));

            mesh.uv2 = uvs.ToArray();
            _meshFilter.sharedMesh = mesh;
        }

        protected void PreparationToDestroy(ParticleActionType particleActionType)
        {
            StopLiveTimer();
            ActionParticleInfo actionParticleInfoData = new ActionParticleInfo
                (particleActionType, transform.position);

            OnParticleSpawned?.Invoke(actionParticleInfoData);
        }

        protected abstract void DestroyBlock();

        private IEnumerator LiveTimer(float liveDuration)
        {
            yield return new WaitForSeconds(liveDuration);
            DestroyBlock();
        }

        private void StopLiveTimer()
        {
            if (_liveTimerCoroutine != null)
                StopCoroutine(_liveTimerCoroutine);
        }
    }
}