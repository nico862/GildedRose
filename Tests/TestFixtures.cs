using GildedRose.Processor;
using GildedRose.TestModels;

namespace GildedRose.Tests
{
    [TestClass]
    public class TestFixtures
    {
        [TestMethod]
        public void Test_Qualtity_Zero()
        {
            var item = new Item { Name = "Quality Zero Item", SellIn = 10, Quality = 0 };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality, result.Quality);
            Assert.AreEqual(item.SellIn, result.SellIn);
        }

        [TestMethod]
        public void Test_SellIn_Zero()
        {
            var item = new Item { Name = "Quality Zero Item", SellIn = 0, Quality = 10 };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.SellIn, result.SellIn);
            Assert.AreEqual(item.Quality, result.Quality);
        }


        [TestMethod]
        public void Test_Sulphuras_No_Change()
        {
            var item = new Item { Name = "Sulphuras item", SellIn = 0, Quality = 80, ItemCategory = TestData.ItemCategory.Sulfurans };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality, result.Quality);
        }

        [TestMethod]
        public void Test_Normal_Decrease()
        {
            var item = new Item { Name = "Normal item", SellIn = 10, Quality = 10, ItemCategory = TestData.ItemCategory.Normal, SellDate = DateTime.Now.AddDays(2) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality -1, result.Quality);
            Assert.AreEqual(item.SellIn -1, result.SellIn);
        }

        [TestMethod]
        public void Test_SellDatePassed()
        {
            var item = new Item { Name = "Normal item sell date passed", SellIn = 10, Quality = 10, ItemCategory = TestData.ItemCategory.Normal, SellDate = DateTime.Now.AddDays(-1) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality - 2, result.Quality);
            Assert.AreEqual(item.SellIn - 1, result.SellIn);
        }

        [TestMethod]
        public void Test_Quality_NeverNegative()
        {
            var item = new Item { Name = "Normal item sell date passed", SellIn = 10, Quality = 1, ItemCategory = TestData.ItemCategory.Normal, SellDate = DateTime.Now.AddDays(-1) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(0, result.Quality);
            Assert.AreEqual(item.SellIn - 1, result.SellIn);
        }

        [TestMethod]
        public void Test_Brie_NormalIncrease()
        {
            var item = new Item { Name = "Aged brie item", SellIn = 20, Quality = 20, ItemCategory = TestData.ItemCategory.Brie, ConcertDate = DateTime.Now.AddDays(15) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality + 1, result.Quality);
        }

        [TestMethod]
        public void Test_Brie_DoubleIncrease()
        {
            var item = new Item { Name = "Aged brie item", SellIn = 20, Quality = 20, ItemCategory = TestData.ItemCategory.Brie, ConcertDate = DateTime.Now.AddDays(10) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality + 2, result.Quality);
        }


        [TestMethod]
        public void Test_Brie_TripleIncrease()
        {
            var item = new Item { Name = "Aged brie item", SellIn = 20, Quality = 20, ItemCategory = TestData.ItemCategory.Brie, ConcertDate = DateTime.Now.AddDays(5) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality + 3, result.Quality);
        }

        [TestMethod]
        public void Test_Quality_NeverMoreThan50()
        {
            var item = new Item { Name = "Aged brie item", SellIn = 20, Quality = 49, ItemCategory = TestData.ItemCategory.Brie, ConcertDate = DateTime.Now.AddDays(5) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(50, result.Quality);
        }

        [TestMethod]
        public void Test_Brie_AfterConcert()
        {
            var item = new Item { Name = "Aged brie item", SellIn = 20, Quality = 20, ItemCategory = TestData.ItemCategory.Brie, ConcertDate = DateTime.Now.AddDays(-1) };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(0, result.Quality);
        }

        [TestMethod]
        public void Test_Conjured_DoubleDecrease()
        {
            var item = new Item { Name = "Conjured item", SellIn = 20, Quality = 20, ItemCategory = TestData.ItemCategory.Conjured };
            var result = new DataProcessor().UpdateQuality(item);
            Assert.AreEqual(item.Quality -2, result.Quality);
        }
    }
}
