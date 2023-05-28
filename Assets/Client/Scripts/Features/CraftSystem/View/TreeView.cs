using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Scripts.Features.CraftSystem.View
{
    public class TreeView : MonoBehaviour
    {
    public Image           Image;
    public Button          Button;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Description;

    public void SetPrice(int price)
    {
        Price.text = price.ToString();
    }
    public void SetTitle(string title)
    {
        Title.text = title;
    }

    public void SetDescription(string description)
    {
        Description.text = description;
    }

    public void SetImage(Sprite image)
    {
        Image.sprite = image;
    }
    }
}