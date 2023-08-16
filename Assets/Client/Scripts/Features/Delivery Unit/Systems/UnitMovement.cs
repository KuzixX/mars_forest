using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Features.Common_Сomponents.Tags;
using Client.Scripts.Features.Delivery_Lander.Components;
using Client.Scripts.Features.Delivery_Unit.Components;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Features.Delivery_Unit.Systems
{
    internal class UnitMovement : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld                                _world;
        private readonly StaticData                              _staticData;
        private readonly SceneData                               _sceneData;
        private readonly EcsFilter<DeliveryUnit>                 _deliveryUnit;
        private readonly EcsFilter<CellObject, IsFull, Position> _cellObjects;
        private readonly EcsFilter<CDeliveryLander>              _deliveryLander;
        public void Init()
        {
            var deliveryUnit = Object.Instantiate(_staticData.DeliveryUnit.Prefab, _sceneData.SpawnPoint.position, Quaternion.identity);
            
            EcsEntity robotEntity                        = _world.NewEntity();
            robotEntity.Get<Position>().transform        = deliveryUnit.transform;
            robotEntity.Get<DeliveryUnit>().NavMeshAgent = deliveryUnit.GetComponent<NavMeshAgent>();
            robotEntity.Get<DeliveryUnit>().IsBusy       = false;
            robotEntity.Get<DeliveryUnit>().Collider     = deliveryUnit.GetComponent<Collider>();
        }

        public void Run()
        {
            foreach (var idx in _deliveryUnit)
            {
              ref var deliveryUnit      = ref _deliveryUnit.Get1(idx);
              var cellAmount         = _cellObjects.GetEntitiesCount();
              var deliveryLander        = _deliveryLander.Get1(0);
              
              if (deliveryUnit.Collider.bounds.Intersects(deliveryLander.Collider.bounds))
              {
                  deliveryUnit.IsBusy = false;
              }
              
              if (cellAmount > 0 && !deliveryUnit.IsBusy)
              {
                  deliveryUnit.TargetId      = Random.Range(0, cellAmount);
                  ref var cellObjectPosition = ref _cellObjects.Get3(deliveryUnit.TargetId);
                  deliveryUnit.NavMeshAgent.SetDestination(cellObjectPosition.transform.position);
                  deliveryUnit.IsBusy        = true;
              }
              
              else if (deliveryUnit.IsBusy)
              {
                  ref var cellObject = ref _cellObjects.GetEntity(deliveryUnit.TargetId);
                  if (!cellObject.Get<CellObject>().collider.bounds.Intersects(deliveryUnit.Collider.bounds)) return;
                  cellObject.Del<IsFull>();
                  deliveryUnit.NavMeshAgent.SetDestination(_sceneData.SpawnPoint.position);
              }  
            }
            
        }
    }
}