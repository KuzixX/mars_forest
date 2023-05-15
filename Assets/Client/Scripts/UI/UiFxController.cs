using Client.Scripts.Models;
using UnityEngine;

namespace Client.Scripts.UI
{
    public class UiFxController : MonoBehaviour
    {
        [SerializeField] private UI ui;
        [SerializeField] private SceneData sceneData;

        private void Update()
        {
            RemoveParticles(ui.goldUIParticleSystem, sceneData.ForceFieldsGold);
            RemoveParticles(ui.diamondsUIParticleSystem, sceneData.ForceFieldsDiamonds);
            RemoveParticles(ui.expUIParticleSystem, sceneData.ForceFieldsExp);
        }

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
