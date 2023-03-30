using Client.Scripts.ECS_Feature.Components;
using Client.Scripts.ECS.Components;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS.System
{
    internal class SelectCellObjectSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private readonly EcsFilter<TouchEvent> _touch;
        private readonly EcsFilter<CellObject, Position> _trees;
        private readonly EcsFilter<SpawnCellObjectData> _spawnData;
        private readonly EcsFilter<GetTreePositionComponent> _selectedTree;
        private readonly EcsFilter<GetRayHitComponent> _rayHit;

        public void Run()
        {
            if (_touch.IsEmpty()) return;

            ref var selectedTree = ref _selectedTree.GetEntity(0);
            
            foreach (var index in _trees)
            {
                ref var tree = ref _trees.GetEntity(index);

                if (!_trees.IsEmpty() && _spawnData.IsEmpty() && selectedTree.Get<GetTreePositionComponent>().TreePos == tree.Get<Position>().transform.position)
                {
                    tree.Get<Selected>();
                    tree.Get<CellObject>().isSelected.SetActive(true);
                    selectedTree.Get<GetTreePositionComponent>().TreePos = Vector3.zero;
                }
                else
                {
                    tree.Del<Selected>();
                    tree.Get<CellObject>().isSelected.SetActive(false);
                }
            }
        }
    }
}
