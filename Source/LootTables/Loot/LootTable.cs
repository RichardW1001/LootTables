using System;
using System.Collections.Generic;
using System.Linq;

namespace Loot
{
    public class LootTable
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly ILogger _logger;
        private readonly IEnumerable<ItemWeighting> _itemWeightings; //TODO: As these would probably vary based on the player's status and other things they would probably come from a service

        public LootTable(IEnumerable<ItemWeighting> itemWeightings, IRandomGenerator randomGenerator, ILogger logger)
        {
            _randomGenerator = randomGenerator;
            _logger = logger;
            _itemWeightings = itemWeightings.ToArray();
        }

        public Item RollItem(string playerName)
        {
            var totalWeight = _itemWeightings.Sum(w => w.Weight);
            var seed = _randomGenerator.NextDouble();
            var seedWeight = seed * totalWeight;

            var randomItem = _itemWeightings.
                TakeWhileAggregate((ItemWeighting i, double a) => a + i.Weight, a => a <= seedWeight).
                LastOrDefault();

            if (randomItem == null)
            {
                throw new InvalidOperationException();
            }

            _logger.LogItemReceived(playerName, randomItem.Item.Name);

            return randomItem.Item;
        }
    }
}