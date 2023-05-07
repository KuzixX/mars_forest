using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.Quest_System.Component;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Client.Scripts.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.CellObjectLevelUp
{
    internal class CellObjectLvlUp : IEcsInitSystem
    {
        private Scripts.UI.UI _ui;
        private SqlLiteDB _sqlDB;
        private readonly EcsFilter<CellObject> _trees;
        private readonly EcsFilter<GameState> _resources;

        public void Init()
        {
            _ui.mainScreen.treeLvlUpBtn.onClick.AddListener(() =>
            {
                ref var res = ref _resources.Get1(0);
                ref var tree = ref _trees.GetEntity(Random.Range(0, _trees.GetEntitiesCount()));
                if (!_trees.IsEmpty() && res.gold >= tree.Get<CellObject>().upgradePrice)
                {
                    res.gold -= tree.Get<CellObject>().upgradePrice;
                    tree.Get<CellObject>().upgradePrice += 10;
                    tree.Get<CellObject>().level += 1;
                    tree.Get<CellObject>().levelUpTitle.SetActive(true);
                    tree.Get<QuestEvent>().QuestType = "TreeLevel";
                    tree.Get<QuestEvent>().Value = tree.Get<CellObject>().level;
                    _sqlDB.UpdateCellObjectData("WorldElements", "Level", tree.Get<CellObject>().level,tree.Get<CellObject>().id);
                    _ui.mainScreen.goldAmountText.text = res.gold.ToString();
                    
                }
            });
        }
    }
}