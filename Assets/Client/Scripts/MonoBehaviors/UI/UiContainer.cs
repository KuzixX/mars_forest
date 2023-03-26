using System;
using System.Collections.Generic;
using Leopotam.Ecs.Ui.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.MonoBehaviors.UI
{
    public class UiContainer : MonoBehaviour
    {
        public List<TextMeshElement> textMeshElements;
        public List<ImageElement> imageElements;
        public List<GameObjectElement> gameObjectElements;
        public List<EcsActionElement> ecsActionElements;
        public GameObject GetObject(string elementName)
        {
            for (int i = 0; i < gameObjectElements.Count; i++)
            {
                if (gameObjectElements[i].name == elementName)
                {
                    return gameObjectElements[i].gameObject;
                }
            }

            return null;
        }
        public TextMeshProUGUI GetTextMesh(string elementName)
        {
            for (int i = 0; i < textMeshElements.Count; i++)
            {
                if (textMeshElements[i].name == elementName)
                {
                    return textMeshElements[i].text;
                }
            }

            return null;
        }
        public Image GetImage(string elementName)
        {
            for (int i = 0; i < imageElements.Count; i++)
            {
                if (imageElements[i].name == elementName)
                {
                    return imageElements[i].image;
                }
            }

            return null;
        }
        public EcsUiClickAction GetEcsActionElement(string elementName)
        {
            for (int i = 0; i < ecsActionElements.Count; i++)
            {
                if (ecsActionElements[i].name == elementName)
                {
                    return ecsActionElements[i].action;
                }
            }
            return null;
        }
    }

    [Serializable]
    public class TextMeshElement
    {
        public String name;
        public TextMeshProUGUI text;
    }
    [Serializable]
    public class ImageElement
    {
        public String name;
        public Image image;
    }
    [Serializable]
    public class ScreenElement
    {
        public String name;
        public UiContainer uiContainer;
    }
    [Serializable]
    public class GameObjectElement
    {
        public String name;
        public GameObject gameObject;
    }
    [Serializable]
    public class EcsActionElement
    {
        public String name;
        public EcsUiClickAction action;
    }
    
}