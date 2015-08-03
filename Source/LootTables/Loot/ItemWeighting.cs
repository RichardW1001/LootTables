namespace Loot
{
    public class ItemWeighting
    {
        public ItemWeighting(Item item, double weight)
        {
            Weight = weight;
            Item = item;
        }

        public Item Item { get; private set; }
        public double Weight { get; private set; }
    }
}