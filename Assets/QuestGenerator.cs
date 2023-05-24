using Client.Scripts.Features.QuestSystem;
using Client.Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class QuestGenerator : MonoBehaviour
{
   [SerializeField] private QuestSystem questSystem;
   [FormerlySerializedAs("_ui")] public UI ui;
   [SerializeField] private string[] propertyNames;
   [SerializeField] private int minValue;
   [SerializeField] private int maxValue;

   private void Start() 
   {
      for (int i = 0; i < 8; i++)
      {
         var newQuest = Object.Instantiate(questSystem, ui.mainCanvas.transform);
         newQuest.Init(propertyNames[Random.Range(0, propertyNames.Length)], 0,Random.Range(minValue, maxValue));
      }
   }
}
