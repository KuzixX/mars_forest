using Client.Scripts.Data;

namespace Client.Scripts.ECS.Components
{
    internal struct ShopItemComponent
    {
        public int Price;
        public ProductType ProductType;
        public PriceType PriceType;
    }
}