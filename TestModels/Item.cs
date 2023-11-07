using GildedRose.TestData;

namespace GildedRose.TestModels
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public ItemCategory ItemCategory { get; set; } = ItemCategory.Normal;
        public DateTime ConcertDate { get; set; }
        public DateTime SellDate { get; set; }
    }
}
