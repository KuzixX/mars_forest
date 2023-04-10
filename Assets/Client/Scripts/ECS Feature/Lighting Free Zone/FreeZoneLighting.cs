using Client.Scripts.Data;
using Client.Scripts.ECS_Feature.Components;
using Client.Scripts.ECS.Components;
using Client.Scripts.ECS.Components.EventCoponents;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;

namespace Client.Scripts.ECS_Feature.Lighting_Free_Zone
{
    sealed class FreeZoneLighting : IEcsRunSystem
    {
        private readonly StaticData _staticData;
        private readonly EcsFilter<Cell, Position> _cells;
        private readonly EcsFilter<EcsUiClickEvent> _clickEvents;
        private readonly EcsFilter<OnSetTreeEvent> _setTreeEvent;
        private readonly EcsFilter<SpawnCellObjectData> _tempSpawnData;

        public void Run()
        {
            foreach (var index in _cells)
            {
                ref var cell = ref _cells.GetEntity(index);
                ref var clickData = ref _clickEvents.Get1(0);

                for (int i = 0; i < _staticData.TreesData.Length; i++)
                {
                    if (!cell.Has<TakenCell>() & clickData.WidgetName == _staticData.TreesData[i].Title && !_tempSpawnData.IsEmpty())
                    {
                        cell.Get<Cell>().lightingCell.SetActive(true);
                    }
                    else if (!_setTreeEvent.IsEmpty())
                    {
                        cell.Get<Cell>().lightingCell.SetActive(false);
                    }
                }
            }
        }
    }
}