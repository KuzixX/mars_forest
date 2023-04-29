using System.Collections.Generic;
using Client.Scripts.ECS_Feature.Common_Сomponents;
using Client.Scripts.ECS_Feature.ECS_Feature_old.EventCoponents;
using Client.Scripts.ECS_Feature.Resources_Generation.Component;
using Firebase.Firestore;
using Leopotam.Ecs;

namespace Client.Scripts.ECS_Feature.ECS_Feature_old.Firebase
{
    internal class UpdateServerData : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<CellObject> _cellObject;
        private readonly EcsFilter<FirebaseComponent> _db;
        private readonly EcsFilter<GameState> _resources;
        private readonly EcsFilter<OnSetTreeEvent> _onSetCellObject;

        public void Init()
        {
            ref var db = ref _db.Get1(0);
            // Get Instance Of Firebase
            db.Firestore = FirebaseFirestore.DefaultInstance;
        }

        public void Run()
        {
            ref var db = ref _db.Get1(0);
            ref var resources = ref _resources.Get1(0);
            // Update cell objects on Firebase
            if (!_onSetCellObject.IsEmpty())
            {
                ref var cellObject = ref _cellObject.GetEntity(_cellObject.GetEntitiesCount() - 1);

                // Create maps
                db.CellObjectData = new Dictionary<string, object>();
                db.ObjectToSendToDB = new Dictionary<string, object>();

                // Add data
                db.CellObjectData.Add("Id", cellObject.Get<CellObject>().id);
                db.CellObjectData.Add("Level", cellObject.Get<CellObject>().level);
                db.CellObjectData.Add("PosX", cellObject.Get<CellObject>().treePrefab.gameObject.transform.position.x);
                db.CellObjectData.Add("PosY", cellObject.Get<CellObject>().treePrefab.gameObject.transform.position.y);
                db.CellObjectData.Add("PosZ", cellObject.Get<CellObject>().treePrefab.gameObject.transform.position.z);

                // Add map to map
                db.ObjectToSendToDB.Add(
                    $"Element{cellObject.Get<CellObject>().title}.id{cellObject.Get<CellObject>().id}",
                    db.CellObjectData);

                // Send data
                db.Firestore.Collection("Users").Document(db.Auth.CurrentUser.UserId).Collection("Game Progress")
                    .Document("World Elements").SetAsync(db.ObjectToSendToDB, SetOptions.MergeAll);
            }

            if (resources.gold != resources.tempGold || resources.experience != resources.tempExperience ||
                resources.diamonds != resources.tempDiamonds)
            {
                resources.tempGold = resources.gold;
                db.Firestore.Collection("Users").Document(db.Auth.CurrentUser.UserId).Collection("Game Progress")
                    .Document("In Game Resources")
                    .SetAsync(
                        new Dictionary<string, object>()
                        {
                            {
                                "Gold", resources.gold
                            },
                            {
                                "Experience", resources.experience
                            },
                            {
                                "Diamonds", resources.diamonds
                            }
                        }, SetOptions.MergeAll);
            }
        }
    }
}