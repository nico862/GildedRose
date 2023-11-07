using System.Collections.Generic;
using GildedRose.TestModels;

namespace GildedRose.Processor
{
    public class DataProcessor
    {

        public Item UpdateQuality(Item input)
        {
            var result = new Item();
            if (input.ItemCategory == TestData.ItemCategory.Sulfurans || input.SellIn == 0 || input.Quality == 0)
            {
                return input;
            }

            switch (input.ItemCategory)
            {
                case TestData.ItemCategory.Normal:
                    if (input.SellIn > 0)
                    {
                        if(input.SellDate < DateTime.Now)
                        {
                            result.Quality = input.Quality - 2;
                        }
                        else
                        {
                            result.Quality = input.Quality - 1;
                        }
                        result.SellIn = input.SellIn - 1;
                    }

                    result.Quality = result.Quality < 0 ? 0 : result.Quality;
                    break;
                case TestData.ItemCategory.Brie:
                    if (input.ConcertDate >= DateTime.Now)
                    {
                        var days = (input.ConcertDate - DateTime.Now).Days;
                        result.SellIn = input.SellIn - 1;
                        if (days <= 5)
                        {
                            result.Quality = input.Quality + 3;
                        }
                        else if (days <= 10)
                        {
                            result.Quality = input.Quality + 2;
                        }
                        else
                        {
                            result.Quality = input.Quality + 1;
                        }
                    }
                    else
                    {
                        result.Quality = 0;
                    }

                    result.Quality = result.Quality > 50 ? 50 : result.Quality;
                    break;
                case TestData.ItemCategory.Conjured:
                    if (input.SellIn > 0)
                    {
                        result.Quality = input.Quality - 2;
                        result.SellIn = input.SellIn - 1;
                    }
                    result.Quality = result.Quality < 0 ? 0 : result.Quality;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
