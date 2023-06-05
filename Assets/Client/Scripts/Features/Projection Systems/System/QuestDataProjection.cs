using Client.Scripts.Features.Common_Сomponents;
using Client.Scripts.Protocols.Interfaces;
using Client.Scripts.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Features.Projection_Systems.System
{
    internal class QuestDataProjection : IEcsRunSystem
    {
        private readonly EcsFilter<GameStateChange> _events;
        private IQuestDataProtocol                  _questDataProtocol;
        public QuestDataProjection(IQuestDataProtocol questDataProtocol)
        {
            _questDataProtocol = questDataProtocol;
        }
        public void Run()
        {
            foreach (var idx in _events)
            {
                ref var gameSateEntity = ref _events.Get1(idx);
                switch (gameSateEntity.EventType)
                {
                    case Events.GoldAdd:
                        _questDataProtocol.Gold.Value = gameSateEntity.Value;
                        Debug.Log("Quest Gold projected");
                        break;
                    case Events.DiamondsAdd:
                        _questDataProtocol.Diamonds.Value = gameSateEntity.Value;
                        Debug.Log("Quest Diamonds projected");
                        break;
                    case Events.ExperienceAdd:
                        _questDataProtocol.Experience.Value = gameSateEntity.Value;
                        Debug.Log("Quest Experience projected");
                        break;
                    case Events.CellObjectAdd:
                        _questDataProtocol.CellObjects.Value = gameSateEntity.Value;
                        Debug.Log("Quest CellObjects projected");
                        break;
                    case Events.GameLevel:
                        _questDataProtocol.GameLevel.Value = gameSateEntity.Value;
                        Debug.Log("Quest GameLevel projected");
                        break;
                }
            }
        }
    }
}