using Client.Scripts.Models;
using UnityEngine;

namespace Client.Scripts.UI
{
    public class UiFxController : MonoBehaviour
    {
        [SerializeField] private UI ui;
        [SerializeField] private ParticleSystemForceField forceFieldsGold;
        [SerializeField] private ParticleSystemForceField forceFieldsDiamonds;
        [SerializeField] private ParticleSystemForceField forceFieldsExp;

        private static void RemoveParticles(ParticleSystem particlesSys, ParticleSystemForceField forceField)
        {
            if (particlesSys.particleCount <= 0) return;
            var particles = new ParticleSystem.Particle[particlesSys.main.maxParticles];
            var numParticlesAlive = particlesSys.GetParticles(particles);
            for (var i = 0; i < numParticlesAlive; i++)
            {
                if (!(Vector3.Distance(forceField.transform.position,
                        particles[i].position) < 0.1)) continue;
                particles[i].remainingLifetime = 0f;
                particlesSys.SetParticles(particles);
            }
        }
    }
}
