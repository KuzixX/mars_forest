using System.Collections.Generic;
using Client.Scripts.Features.Commands;
using Client.Scripts.Features.CraftSystem.Models;
using Client.Scripts.Models;
using Client.Scripts.Protocols.Interfaces;
using UnityEngine;
using Zenject;
using Client.Scripts.Features.CraftSystem.View;

namespace Client.Scripts.Features.CraftSystem.Presenter
{
    public class CraftPresenter : MonoBehaviour
    {
        private TreeView                                             _treeView;
        private List<DecorModel>                                     _decorModels;
        private List<HouseModel>                                     _houseModels;
        private List<TreeModel>                                      _treeModels;
        [SerializeField] private StaticData                           staticData;
        [Inject(Id = "TreesContainer")] private ICraftItemTransform  _tressContainer;
        [Inject(Id = "DecorContainer")] private ICraftItemTransform  _decorContainer;
        [Inject(Id = "HousesContainer")] private ICraftItemTransform _housesContainer;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _decorModels = new List<DecorModel>();
            _houseModels = new List<HouseModel>();
            _treeModels  = new List<TreeModel>();

            foreach (var tree in staticData.TreesData)
            {
                var newTree = new TreeModel();
                newTree.Title = tree.Title;
                newTree.Description = tree.Description;
                newTree.AmountOfExperience = tree.AmountOfExperience;
                newTree.AmountOfProduct = tree.AmountOfProduct;
                newTree.Image = tree.Image;
                newTree.Level = tree.Level;
                newTree.Prefab = tree.Prefab;
                newTree.Price = tree.Price;
                newTree.ProductionCycleTime = tree.ProductionCycleTime;
                newTree.EcsCommand = new SpawnCraftItem(tree.Title); 
                _treeModels.Add(newTree);
            }

            foreach (var tree in _treeModels)
            {
                var treeView = Instantiate(staticData.UiItemElement, _tressContainer.RectTransform);
                treeView.GetComponent<TreeView>().SetTitle(tree.Title);
                treeView.GetComponent<TreeView>().SetDescription(tree.Description);
                treeView.GetComponent<TreeView>().SetPrice(tree.Price);
                treeView.GetComponent<TreeView>().SetImage(tree.Image);
                treeView.GetComponent<TreeView>().Button.onClick.AddListener(() => {tree.EcsCommand.Execute();});
            }
        }
    }
}