using UnityEngine;

namespace WarFriends.Legacy
{
    [DisallowMultipleComponent]
    public sealed class ParticleEmitterCompat : MonoBehaviour
    {
        private ParticleSystem CachedParticleSystem
        {
            get { return GetComponent<ParticleSystem>(); }
        }

        public bool emit
        {
            get
            {
                ParticleSystem particleSystem = CachedParticleSystem;
                return particleSystem != null && particleSystem.emission.enabled;
            }
            set
            {
                ParticleSystem particleSystem = CachedParticleSystem;
                if (particleSystem != null)
                {
                    ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
                    emissionModule.enabled = value;
                }
            }
        }

        public int particleCount
        {
            get
            {
                ParticleSystem particleSystem = CachedParticleSystem;
                return particleSystem == null ? 0 : particleSystem.particleCount;
            }
        }
    }
}
