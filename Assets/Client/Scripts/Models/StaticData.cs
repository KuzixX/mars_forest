using Client.Scripts.Models.UI;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Client.Scripts.Models
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [field: Header("Trees")] 
        [SerializeField] protected ItemInfo[] treesData;
        public ItemInfo[] TreesData => treesData;
        [Header("Quests")]
        [SerializeField] protected Quest[] quests;
        public Quest[] Quest => quests;
        [Header("Stuff")] 
        [SerializeField] protected Product[] products;
        public Product[] Products => products;
        [Header("Diamonds")] 
        [SerializeField] protected Diamonds[] diamonds;
        public Diamonds[] Diamonds => diamonds;
        [Header("Units")]
        [SerializeField] protected Character mainCharacter;
        public Character MainCharacter => mainCharacter;
        [SerializeField] protected Unit deliveryUnit;
        public Unit DeliveryUnit => deliveryUnit;
        [SerializeField] protected EnvModule deliveryLander;
        public EnvModule DeliveryLander => deliveryLander;
        [Header("Tiles")] 
        [SerializeField] protected TileBase freeTile;
        public TileBase FreeTile => freeTile;
        [SerializeField] protected TileBase lockTile;
        public TileBase LockTile => lockTile;
        [SerializeField] protected GameObject lightDisk;
        public GameObject LightDisk => lightDisk;
        [Header("Other")]
        [SerializeField] protected Transform target;
        public Transform Target => target;
        [SerializeField] protected Transform defaultCamPos;
        public Transform DefaultCamPos => defaultCamPos;
        [Header("UI")] 
        [SerializeField] private GameObject levelUpTitle;
        public GameObject LevelUpTitle => levelUpTitle;
        [SerializeField] private GameObject uiItemElement;
        public GameObject UiItemElement => uiItemElement;
        [SerializeField] private GameObject goldSprite;
        public GameObject GoldSprite => goldSprite;
        [SerializeField] private QuestItem uiQuestElement;
        public QuestItem UiQuestElement => uiQuestElement;
        [SerializeField] private ShopItem uiShopElement;
        public ShopItem UiShopElement => uiShopElement;
        [Header("Urls")] 
        [SerializeField] private string instagramUrl;
        public string InstagramUrl => instagramUrl;
        [SerializeField] private string youTubeUrl;
        public string YouTubeUrl => youTubeUrl;
        [SerializeField] private string facebookUrl;
        public string FacebookUrl => facebookUrl;
    }
}
 