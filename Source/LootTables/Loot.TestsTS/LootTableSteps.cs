
using System;
using System.Collections.Generic;
using System.Linq;
using Loot;
using TickSpec;
using NUnit.Framework;
using Moq;

namespace LootTable.TestsTS
{
    public class LootTableFixture : FeatureFixture
    {
        public LootTableFixture() : base("LootTable.feature")
        {
        }
    }

    [Binding]
    public class LootTableSteps
    {
        private double _nextRandom;
        private IEnumerable<ItemWeighting> _items;

        private Item _nextItem;
        private Exception _exception;

        private readonly Mock<ILogger> _logger = new Mock<ILogger>();

        [Given(@"the next random number is (.*)")]
        public void GivenTheNextRandomNumberIs(double nextRandom)
        {
            _nextRandom = nextRandom;
        }

        [Given(@"the loot table")]
        public void GivenTheLootTable(Table table)
        {
            _items = table.Rows.
                Select(r => new ItemWeighting(new Item(r[0]), Convert.ToDouble(r[1]))).
                ToArray();
        }

        [When(@"rolling for a loot item for ""(.*)""")]
        public void WhenRollingForALootItem(string playerName)
        {
            var random = new Mock<IRandomGenerator>();
            random.Setup(r => r.NextDouble()).Returns(_nextRandom);

            var target = new Loot.LootTable(_items, random.Object, _logger.Object);

            try
            {
                _nextItem = target.RollItem(playerName);
            }
            catch (Exception e)
            {
                _exception = e;
            }
        }

        [Then(@"the loot item should be ""(.*)""")]
        public void ThenTheLootItemShouldBe(string item)
        {
            Assert.IsNotNull(_nextItem);
            Assert.AreEqual(item, _nextItem.Name);
        }

        [Then(@"there should be an error")]
        public void ThenThereShouldBeAnError()
        {
            Assert.IsNotNull(_exception);
            //TODO: Make the exception more meaningful
        }

        [Then(@"a log entry should show ""(.*)"" given to ""(.*)""")]
        public void ThenALogEntryShouldShowGivenTo(string item, string player)
        {
            _logger.Verify(l => l.LogItemReceived(player, item));
        }
    }
}
