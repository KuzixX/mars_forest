using Client.Scripts.Features.Delivery_Lander.Components;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.Delivery_Lander.Systems
{
    internal class DeliveryLander : IEcsInitSystem
    {
        private readonly EcsFilter<CDeliveryLander> _deliveryLander;
        private readonly StaticData _staticData;
        private readonly SceneData  _sceneData;
        private readonly EcsWorld   _world;
        public void Init()
        {
            var deliveryLander                = Object.Instantiate(_staticData.DeliveryLander.Prefab, _sceneData.SpawnPoint.position, Quaternion.identity);
            EcsEntity landerEntity                       = _world.NewEntity();
            landerEntity.Get<CDeliveryLander>().Collider = deliveryLander.GetComponent<Collider>();
        }
    }
}