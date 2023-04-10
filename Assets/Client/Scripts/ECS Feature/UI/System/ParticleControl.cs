using Client.Scripts.Data;
using Client.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.UI.System
{
    internal class ParticleControl : IEcsRunSystem
    {
        private readonly EcsFilter<QuestComponent> _quests;
        private readonly EcsFilter<CellObject> _trees;
        private SceneData _sceneData;
        private MonoBehaviors.UI.UI _ui;

        public void Run()
        {
            foreach (var index in _trees)
            {
                // Delete gold particles
                if (_ui.goldUIParticleSystem.particleCount > 0)
                {
                    var particles = new ParticleSystem.Particle[_ui.goldUIParticleSystem.main.maxParticles];
                    var numParticlesAlive = _ui.goldUIParticleSystem.GetParticles(particles);
                    for (int i = 0; i < numParticlesAlive; i++)
                    {
                        if (Vector3.Distance(_sceneData.ForceFieldsGold.transform.position,
                                particles[i].position) < 0.1)
                        {
                            particles[i].remainingLifetime = 0f;
                            _ui.goldUIParticleSystem.SetParticles(particles);
                        }
                    }
                }

                // Delete exp particles
                if (_ui.expUIParticleSystem.particleCount > 0)
                {
                    var particles = new ParticleSystem.Particle[_ui.expUIParticleSystem.main.maxParticles];
                    var numParticlesAlive = _ui.expUIParticleSystem.GetParticles(particles);
                    for (int i = 0; i < numParticlesAlive; i++)
                    {
                        if (Vector3.Distance(_sceneData.ForceFieldsExp.transform.position,
                                particles[i].position) < 0.1)
                        {
                            particles[i].remainingLifetime = 0f;
                            _ui.expUIParticleSystem.SetParticles(particles);
                        }
                    }
                }

                if (_ui.diamondsUIParticleSystem.particleCount > 0)
                {
                    var particles = new ParticleSystem.Particle[_ui.diamondsUIParticleSystem.main.maxParticles];
                    var numParticlesAlive = _ui.diamondsUIParticleSystem.GetParticles(particles);
                    for (int i = 0; i < numParticlesAlive; i++)
                    {
                        if (Vector3.Distance(_sceneData.ForceFieldsDiamonds.transform.position,
                                particles[i].position) < 0.1)
                        {
                            particles[i].remainingLifetime = 0f;
                            _ui.diamondsUIParticleSystem.SetParticles(particles);
                        }
                    }
                }
            }
        }
    }
}