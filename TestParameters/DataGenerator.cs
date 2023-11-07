using GildedRose.TestModels;

namespace GildedRose.TestParameters
{
    public static class DataGenerator
    {
        public static List<Item> CreateItemsList()
        {
            return new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, ItemCategory = TestData.ItemCategory.Normal},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, ItemCategory = TestData.ItemCategory.Sulfurans},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80, ItemCategory = TestData.ItemCategory.Sulfurans},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20,
                    ConcertDate = DateTime.Now.AddDays(10),
                    ItemCategory = TestData.ItemCategory.Brie
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49,
                    ItemCategory = TestData.ItemCategory.Brie,
                    ConcertDate = DateTime.Now.AddDays(10)
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, ItemCategory = TestData.ItemCategory.Conjured}
    };

        }
    }
}
